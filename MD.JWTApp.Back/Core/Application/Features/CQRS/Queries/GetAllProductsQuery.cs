using MD.JWTApp.Back.Core.Application.Dtos;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQuery:IRequest<List<ProductListDto>>
    {

    }
}
