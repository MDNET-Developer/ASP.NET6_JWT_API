using AutoMapper;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            //var mappedData = _mapper.Map<Category>(request);
            //await _categoryRepo.UpdateAsync(mappedData);

            var getId = await _categoryRepo.GetByIdAsync(request.Id);
            if (getId != null)
            {
                getId.Definiton = request.Definiton;
                await _categoryRepo.UpdateAsync(getId);
            }
       
            return Unit.Value;


        }
    }
}
