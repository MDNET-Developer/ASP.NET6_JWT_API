using MD.JWTApp.Back.Core.Application.Dtos;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoryQueryRequest:IRequest<List<CategoryListDto>>
    {
    }
}
