using MediatR;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GeAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {

    }
}
