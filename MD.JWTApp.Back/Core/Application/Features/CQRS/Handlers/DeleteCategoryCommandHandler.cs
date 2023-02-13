using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepo;

        public DeleteCategoryCommandHandler(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var getId = await _categoryRepo.GetByIdAsync(request.Id);
            if (getId != null)
            {
                await _categoryRepo.RemoveAsync(getId);
            }
            return Unit.Value;
        }
    }
}
