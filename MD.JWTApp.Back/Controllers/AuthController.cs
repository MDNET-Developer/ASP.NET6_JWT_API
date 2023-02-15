using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MD.JWTApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUser)
        {
            await _mediator.Send(registerUser);
            return Ok($"{ registerUser.UserName} adlı istifadəçi uğurla qeydiyyatdan keçdi.");
        }
    }
}
