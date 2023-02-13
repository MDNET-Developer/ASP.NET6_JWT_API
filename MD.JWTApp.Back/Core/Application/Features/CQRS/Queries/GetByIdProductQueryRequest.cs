using MD.JWTApp.Back.Core.Application.Dtos;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetByIdProductQueryRequest:IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetByIdProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
