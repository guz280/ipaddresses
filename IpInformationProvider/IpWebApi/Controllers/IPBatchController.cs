using System;
using System.Linq;
using IpWebApi.Models;
using System.Threading;
using IpWebApi.Business;
using IpWebApi.Workers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;


namespace IpWebApi.Controllers
{
    [ApiController]
    public class IPBatchController : ControllerBase
    {
        private readonly IServiceProvider _iserviceProvider;
        private readonly IIpBatchBusinessInterface _ipBatchBusinessInterface;
        private IMemoryCache _cache;

        public IPBatchController(IServiceProvider iserviceProvider, IIpBatchBusinessInterface ipBatchBusinessInterface, IMemoryCache cache)
        {
            _iserviceProvider = iserviceProvider;
            _ipBatchBusinessInterface = ipBatchBusinessInterface;
            _cache = cache;
        }

        [HttpPut]
        [Route("api/")]
        public ActionResult UpdateRequest()
        {
            var file = _ipBatchBusinessInterface.ReadFile();

            string[] ips = file.Split(',').ToArray();

            // Create Request
            IpRequest ipRequest = _ipBatchBusinessInterface.CreateRequest(ips);


            // add to cache the ip list & ipRequest
            CommonBusiness cb = new CommonBusiness(_cache);
            cb.SetCache<string[]>("IpListArray", ips, 20);
            cb.SetCache<IpRequest>("IpRequest", ipRequest, 20);

            // Create a dedicate background thread that will be running along side the web server.
            Thread counterBackgroundWorkerThread = new Thread(BatchHandlerAsync)
            {
                IsBackground = true
            };
            
            counterBackgroundWorkerThread.Start();

            // create new guid for reference

            return Ok(ipRequest.guid);

        }

       

        [HttpGet("{guid}")]
        public ActionResult GetJobProgress(string guid)
        {
            // get the cache list
            IpRequest ipRequest = _cache.Get<IpRequest>("IpRequest");

            if((ipRequest == null) || (ipRequest.guid.ToString() != guid))
            {
                return StatusCode(500);
            }
            // get the number of ips that processed is equal to  true
            int count = 0;
            foreach (var item in ipRequest.IpStatus)
            {
                if (item.Value.Processed)
                {
                    count++;
                }
            }
            string status = count + "/" + ipRequest.IpStatus.Count.ToString();

            return Ok(status);

        }


        #region Private Methods
        private async void BatchHandlerAsync(object obj)
        {
            using (IServiceScope scope = _iserviceProvider.CreateScope())
            {
                BackgroundWorker backgroundWorker = scope.ServiceProvider.GetRequiredService<BackgroundWorker>();

                await backgroundWorker.ExecuteAsync();
            }
        }
        #endregion


    }
}
