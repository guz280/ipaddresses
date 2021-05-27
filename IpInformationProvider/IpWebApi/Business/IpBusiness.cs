using IIpInformationProvider;
using IpWebApi.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace IpWebApi.Business
{
    public class IpBusiness : IpBusinessInterface
    {
        private readonly IpDetailsDbContext _context;
        private IMemoryCache _cache;

        public IpBusiness(IpDetailsDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _cache = memoryCache;
        }

        public async Task<IpDetails> GetIpDetailsAsync(string ip)
        {
            CommonBusiness cb = new CommonBusiness(_cache);
            // Step1 -> get from cache
            var cacheKey = ip;

            IpDetails cacheData = _cache.Get<IpDetails>(cacheKey);

            if (cacheData != null)
            {
                return cacheData;
            }

            // Step2 -> get from DB
            var resultDb = _context.Details.Where(i => i.Ip == ip).FirstOrDefault();

            if (resultDb != null)
            {
                IpDetails details = MapFromDBModel(resultDb);
                cb.SetCache<IpDetails>(cacheKey, details, 1);
                return details;
            }

            // Step 3 -> get IpDetails from api
            IIpInfoProvider iip = new IIpInfoProvider();
            var resultApi = await iip.GetDetails(ip);

            if(resultApi == null)
            {
                return null;
            }

            // Step 4 -> save to DB
            _context.Details.Add(cb.MapToDBModel(resultApi, ip));
            await _context.SaveChangesAsync();

            // Step 5 -> save to cache
            cb.SetCache<IpDetails>(cacheKey, resultApi, 1);


            return resultApi;
        }





        #region Private methods
        private IpDetails MapFromDBModel(Details dbModel)
        {
            return new IpDetails
            {
                City = dbModel.City,
                Continent = dbModel.Continent,
                Country = dbModel.Country,
                Latitude = Convert.ToDouble(dbModel.Latitude),
                Longitude = Convert.ToDouble(dbModel.Longitude)
            };
        }
        #endregion
    }
}
