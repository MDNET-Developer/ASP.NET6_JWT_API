using AutoMapper;
using MD.JWTApp.Back.Core.Application.Dtos;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, ProductListDto>
    {

        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var defaultdata = await _productRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ProductListDto>(defaultdata);
        }
    }
}
