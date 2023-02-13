using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommand:IRequest
    {
        public string? Definiton { get; set; }
    }
}
