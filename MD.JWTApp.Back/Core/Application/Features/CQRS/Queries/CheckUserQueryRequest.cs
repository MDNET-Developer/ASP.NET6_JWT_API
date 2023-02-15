using MD.JWTApp.Back.Core.Application.Dtos;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest:IRequest<CheckUserResponseDto>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
