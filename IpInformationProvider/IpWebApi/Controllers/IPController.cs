using IIpInformationProvider;
using IpWebApi.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpWebApi.Controllers
{
    [Route("api/ipdetails")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private readonly IpBusinessInterface _ipBusinessInterface;

        public IPController(IpBusinessInterface ipBusinessInterface)
        {
            this._ipBusinessInterface = ipBusinessInterface;
        }

        [HttpGet("{ip}")]
        public async Task<ActionResult<IpDetails>> GetIpDetailsAsync(string ip)
        {
            var result = await _ipBusinessInterface.GetIpDetailsAsync(ip);

            if(result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
            
        }


    }
}
