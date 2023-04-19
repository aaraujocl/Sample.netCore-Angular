using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Student.Commands.Create;
using Sample.Application.Student.Commands.Delete;
using Sample.Application.Student.Commands.Query;
using Sample.Application.Student.Commands.Query.GetStudent;
using Sample.Application.Student.Commands.Query.GetStudents;
using Sample.Application.Student.Commands.Update;
using Sample.Core.Domain;
using System.Threading.Tasks;

namespace Sample.Api.Students.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetStudentQuery
            {
             
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStudentDto student)
        {

            var result = await _mediator.Send(new CreateStudentCommand(student));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateStudentDto student)
        {
            var result = await _mediator.Send(new UpdateStudentCommand(student, id));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand(id));

            return Ok(result);
        }
    }
}
