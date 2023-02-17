using MD.JWTApp.Back.Core.Application.Features.CQRS.Commands;
using MD.JWTApp.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MD.JWTApp.Back.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allData = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(allData);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCatagory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok($"{command.Definiton} kateqoriyası uğurla əlavə olundu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCatagory(UpdateCategoryCommand update)
        {
            await _mediator.Send(update);
            return Ok($"{update.Definiton} kateqoriyası uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var getDataById =  await _mediator.Send(new GetByIdCategoryQueryRequest(id));
            return Ok(getDataById);
  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var getDataById = await _mediator.Send(new GetByIdCategoryQueryRequest(id));
            if (getDataById != null)
            {
               await _mediator.Send(new DeleteCategoryCommand(id));
                return Ok($"Id={id} olan data uğurla silindi");
            }
            else
            {
                return BadRequest($"Id={id} olan data tapılmadı");
            }
        }
    }
}
