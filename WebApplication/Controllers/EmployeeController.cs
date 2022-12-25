using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Employees.Quieres.GetEmployeeList;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Quieres.GetEmployeeDetails;
using Application.Employees.Commands.DeleteEmployee;
using WebApplication.Models;
using Domain;
using AutoMapper;
using System.Dynamic;
using Application.Employees.Commands.UpdateEmployee;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<EmployeeListVm>> GetAll()
        {
            var query = new GetEmployeeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<EmployeeListVm>> Get(int id)
        {
            var query = new GetEmployeeDetailsQuery
            {
                id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateEmployeeDto createEmployeeDto)
        {
            var command = _mapper.Map<CreateEmployeeCommand>(createEmployeeDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = _mapper.Map<UpdateEmployeeCommand>(updateEmployeeDto);
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteEmployeeCommand
            {
                id = id,
            };
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
