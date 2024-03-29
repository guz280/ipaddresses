﻿using System;
using IpWebApi.Models;
using IIpInformationProvider;
using Microsoft.Extensions.Caching.Memory;

namespace IpWebApi.Business
{
    public class CommonBusiness
    {
        private IMemoryCache _cache;

        public CommonBusiness(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void SetCache<T>(string cacheKey, T data, int minutes)
        {
            MemoryCacheEntryOptions cacheExpirationOptions = new MemoryCacheEntryOptions();
            cacheExpirationOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(minutes);

            _cache.Set<T>(cacheKey, data, cacheExpirationOptions);
        }

        public Details MapToDBModel(IpDetails apiModel, string ip)
        {
            return new Details
            {
                Ip = ip,
                City = apiModel.City,
                Continent = apiModel.Continent,
                Country = apiModel.Country,
                Latitude = Convert.ToSingle(apiModel.Latitude),
                Longitude = Convert.ToSingle(apiModel.Longitude)
            };
        }
    }
}
