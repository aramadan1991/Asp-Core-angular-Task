using Application.Handlers.Employees.Commands;
using Application.Handlers.Employees.Queries;
using Application.Wrappers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IResponse> GetEmployees()
        {
            return await _mediator.Send(new GetAllEmployeesQuery());
        }

        [HttpGet("{id}")]
        public async Task<IResponse> GetEmployee(Guid id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        [HttpPost]
        public async Task<IResponse> CreateEmployee(CreateEmployeeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<IResponse> UpdateEmployee(UpdateEmployeeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<IResponse> DeleteEmployee(Guid id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(id));
        }


    }
}