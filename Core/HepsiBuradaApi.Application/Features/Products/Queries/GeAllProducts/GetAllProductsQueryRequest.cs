using HepsiBuradaApi.Application.Interfaces.RedisCache;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GeAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllProducts";

        public double CacheTime => 60;
    }
}
