using System;
using System.Linq;
using IpWebApi.Models;
using System.Threading;
using IpWebApi.Business;
using IIpInformationProvider;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;


namespace IpWebApi.Workers
{
    public class BackgroundWorker
    {
        private readonly ILogger<BackgroundWorker> _logger;
        private readonly IpDetailsDbContext _context;
        private IMemoryCache _cache;

        private int _counter;

        public BackgroundWorker(ILogger<BackgroundWorker> logger, IMemoryCache cache, IpDetailsDbContext context)
        {
            _counter = 0;
            _logger = logger;
            _cache = cache;
            _context = context;
        }

        public async Task ExecuteAsync()
        {
            try
            {
                CommonBusiness cb = new CommonBusiness(_cache);

                // Divide the whole request in batches
                string[] ipList = _cache.Get<string[]>("IpListArray");

                // hard coded 10 - can be in config file or DB
                int batchNumber = 10;
                int numberOfBatches = ipList.Count() / batchNumber;
                int remainder = ipList.Count() % batchNumber; 
                if (remainder > 0)
                {
                    numberOfBatches++;
                }

                for (int i = 0; i < numberOfBatches; i++)
                {
                    string[] newIpList = ipList.Skip(batchNumber * i).Take(batchNumber).ToArray();

                    // get IpDetails from api for each one in list
                    foreach (var ip in newIpList)
                    {
                        IIpInfoProvider iip = new IIpInfoProvider();
                        var resultApi = await iip.GetDetails(ip);

                        // add or update DB 
                        if (_context.Details.Any(i => i.Ip == ip))
                        {
                            _context.Details.Update(cb.MapToDBModel(resultApi, ip));
                        }
                        else
                        {
                            _context.Details.Add(cb.MapToDBModel(resultApi, ip));
                        }

                        // Update the dictionary to set Processed to true
                        IpRequest ipRequest = _cache.Get<IpRequest>("IpRequest");
                        Status status;
                        ipRequest.IpStatus.TryGetValue(ip, out status);
                        status.Processed = true;
                        ipRequest.IpStatus[ip] = status;

                        cb.SetCache<IpRequest>("IpRequest", ipRequest, 20);


                        // sleep for testing purposes ONLY - to be able to test the get
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }

                    await _context.SaveChangesAsync();
                }

                // Remove IpRequest details from cache after completion
                // This was not removed so that we can test and call the GetJobProgress with guid
                //_cache.Remove("IpRequest");
            }
            catch (Exception e)
            {
                // log exception
                throw;
            }
        }
    }
}
