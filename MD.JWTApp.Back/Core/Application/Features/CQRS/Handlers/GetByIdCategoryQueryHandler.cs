using AutoMapper;
using MD.JWTApp.Back.Core.Application.Dtos;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var getEntityData = await _categoryRepo.GetByFilterAsync(x=>x.Id==request.Id);
            var mappedData = _mapper.Map <CategoryListDto>(getEntityData);
            return mappedData;
        }
    }
}
