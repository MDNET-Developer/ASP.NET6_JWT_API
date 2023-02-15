using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommand:IRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
