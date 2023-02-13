using AutoMapper;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Interfaces;
using MD.JWTApp.Back.Core.Domain;
using MediatR;

namespace MD.JWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var mappeddata = _mapper.Map<Product>(request);
            await _productRepo.UpdateAsync(mappeddata);
            //var mappeddata = _mapper.Map<Product>(request);
            //var getId = await _productRepo.GetByIdAsync(mappeddata.Id);

            //var getId = await _productRepo.GetByIdAsync(request.Id);
            //if (getId != null)
            //{
            //    getId.Name = request.Name;
            //    getId.Price = request.Price;
            //    getId.Stock = request.Stock;
            //    getId.CategoryId = request.CategoryId;
            //    await _productRepo.UpdateAsync(getId);

            //}
            return Unit.Value;
        }
    }
}
