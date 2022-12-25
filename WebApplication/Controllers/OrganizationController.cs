using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Application.Organizations.Queres.GetOrganizationList;
using Application.Organizations;
using Application.Organizations.Commands.UpdateOrganization;
using Application.Organizations.Commands.CreateOrganization;
using Application.Organizations.Commands.DeleteOrganization;
using Application.Organizations.Queres.GetOrganizationDetails;
using WebApplication.Models;
using Domain;
using System.Dynamic;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : BaseController
    {
        private readonly IMapper _mapper;

        public OrganizationController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<OrganizationListVm>> GetAll()
        {
            var query = new GetOrganizationListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<OrganizationListVm>> Get(int id)
        {
            var query = new GetOrganizationsDetailsQuery
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
        public async Task<ActionResult<int>> Create([FromForm] CreateOrganizationDto createOrganizationDto)
        {
            var command = _mapper.Map<CreateOrganizationCommand>(createOrganizationDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateOrganizationDto updateOrganizationDto)
        {
            var command = _mapper.Map<UpdateOrganizationCommand>(updateOrganizationDto);
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
            var command = new DeleteOrganizationCommand
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
