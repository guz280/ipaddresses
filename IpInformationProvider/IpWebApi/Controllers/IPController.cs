using IpWebApi.Business;
using System.Threading.Tasks;
using IIpInformationProvider;
using Microsoft.AspNetCore.Mvc;


namespace IpWebApi.Controllers
{
    [Route("api/ipdetails")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private readonly IIpBusinessInterface _ipBusinessInterface;

        public IPController(IIpBusinessInterface ipBusinessInterface)
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
