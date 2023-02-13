using MD.JWTApp.Back.Core.Application.Dtos;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetByIdCategoryQueryRequest:IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetByIdCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
