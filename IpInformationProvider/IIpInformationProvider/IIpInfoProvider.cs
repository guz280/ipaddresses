using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IIpInformationProvider
{
    

    public class IIpInfoProvider : IIpInfoProviderInterface
    {

        public IIpInfoProvider()
        {
        }

        public async Task<IpDetails> GetDetails(string ip)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string baseUrl = "http://api.ipstack.com/";
                string access_key = "3e22c3e6a54cf7219e5a475fbfe4183b";
                string apirUrl = baseUrl + ip + "?access_key=" + access_key;

                // http call to api
                var response = await httpClient.GetAsync(apirUrl);
                // read result
                var content = await response.Content.ReadAsStringAsync();
                // deserialise string to JSON
                dynamic obj = JsonConvert.DeserializeObject(content);
                // convert json object to model
                var responseModel = obj.ToObject<IPDetailsResponseModel>();

                // check if the model is empty
                if((responseModel.city == null) && (responseModel.country_name == null) && (responseModel.continent_name == null) && (responseModel.latitude == 0) && (responseModel.longitude == 0)){
                    return null;
                }

                IpDetails ipDetails = new IpDetails
                {

                    City = responseModel.city,
                    Continent = responseModel.continent_name,
                    Country = responseModel.country_name,
                    Latitude = responseModel.latitude,
                    Longitude = responseModel.longitude
                };
                return ipDetails;
            }
            catch (Exception e)
            {
                // log exception
                throw new Exception("IPServiceNotAvailableException");
            }
        }

    
    }


    
    

}
