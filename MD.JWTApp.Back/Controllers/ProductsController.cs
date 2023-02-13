using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MD.JWTApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> CreateProduct(UpdateProductCommand update)
        {
            await _mediator.Send(update);
            return Ok(update.Name + "adlı data uğurla yenilendi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct)
        {
            await _mediator.Send(createProduct);
            return Created("" , createProduct);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alldata = await _mediator.Send(new GetAllProductsQuery());
            return Ok(alldata);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getByIdData = await _mediator.Send(new GetByIdProductQueryRequest(id));

            return getByIdData==null? Ok($"Id={id} olan data tapılmadı"): Ok(getByIdData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var getByIdData = await _mediator.Send(new GetByIdProductQueryRequest(id));
            if (getByIdData != null)
            {
                var deleteddata = await _mediator.Send(new DeleteProductCommand(id));
                return Ok($"Id={id} olan data uğurla silindi");
            }
            else
            {
                return Ok($"Id={id} olan data tapılmadı");
            }
       
        }
    }
}
