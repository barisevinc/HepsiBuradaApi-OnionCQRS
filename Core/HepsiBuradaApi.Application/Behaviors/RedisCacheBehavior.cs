using HepsiBuradaApi.Application.Interfaces.RedisCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaApi.Application.Behaviors
{
    public class RedisCacheBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehavior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableQuery query) 
            {
                var cacheKey = query.CacheKey;
                var cacheTime = query.CacheTime;

                var cacheData = await redisCacheService.GetAsync<Tresponse>(cacheKey);
                if (cacheData is not null)
                    return cacheData;

                var response = await next();
                if (response is not null)
                    await redisCacheService.SetAsync(cacheKey, response, DateTime.Now.AddMinutes(cacheTime));

                return response;
            }
            return await next();
        }
    }
}
