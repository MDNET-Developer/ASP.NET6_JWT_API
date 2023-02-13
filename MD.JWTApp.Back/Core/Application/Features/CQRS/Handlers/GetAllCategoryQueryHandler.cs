using AutoMapper;
using MD.JWTApp.Back.Core.Application.Dtos;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(IMapper mapper, IRepository<Category> categoryRepo)
        {

            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var defaultEntity = await _categoryRepo.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(defaultEntity);
        }
    }
}
