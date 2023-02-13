using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
