using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateCategoryCommand:IRequest
    {
        public int Id { get; set; }
        public string? Definiton { get; set; }
    }
}
