using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepo;

        public DeleteProductCommandHandler(IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var getid = await _productRepo.GetByIdAsync(request.Id);
            if (getid != null)
            {
                await _productRepo.RemoveAsync(getid);
            }
            return Unit.Value;
        }
    }
}
