using AutoMapper;
using MD.JWTApp.Back.Core.Application.Dtos;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDto>>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var defaultdata = await _productRepo.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(defaultdata);
        }
    }
}
