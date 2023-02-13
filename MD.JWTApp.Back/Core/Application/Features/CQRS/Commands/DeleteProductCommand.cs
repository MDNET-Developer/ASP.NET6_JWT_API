using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteProductCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
