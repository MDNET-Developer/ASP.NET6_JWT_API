using AutoMapper;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //var mappeddata = _mapper.Map<Category>(request);
            //await _categoryRepo.CreateAsync(mappeddata);

            await _categoryRepo.CreateAsync(new Category()
            {
                Definiton=request.Definiton
            });
            return Unit.Value;
        }
    }
}
