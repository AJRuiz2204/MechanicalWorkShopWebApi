using MechanicalWorkShopWebApi.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mechanical_workshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersWorkshopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersWorkshopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var query = new GetUserWorkshopByIdQuery { Id = id };

            var userViewModel = await _mediator.Send(query);

            if (userViewModel == null)
            {
                return NotFound();
            }

            return Ok(userViewModel);
        }
    }
}