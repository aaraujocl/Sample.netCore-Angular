using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Student.Commands.Create;
using Sample.Application.Student.Commands.Query.GetStudent;
using Sample.Application.User.Commands.Query;
using Sample.Application.User.Commands.SeedWork;
using System.Threading.Tasks;

namespace Sample.Api.Students.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] LoginDto user)
        {

            var result = await _mediator.Send(new GetUserQuery(user));

            return Ok(result);
        }
    }
}
