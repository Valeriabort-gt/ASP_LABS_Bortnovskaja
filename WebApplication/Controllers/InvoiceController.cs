using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using MediatR;
using Application.Invoices.Quieres.GetInvoiceList;
using Application.Invoices.Commands.CreateInvoice;
using Application.Invoices.Quieres.GetInvoiceDetails;
using Application.Invoices.Commands.UpdateInvoice;
using Application.Invoices.Commands.DeleteInvoice;
using Application.Employees.Quieres.GetEmployeeList;
using Application.Organizations.Queres.GetOrganizationList;
using Application.Rooms.Quieres.GetRoomList;
using Application.Employees.Quieres.GetEmployeeList;
using Domain;
using System.Dynamic;
using AutoMapper;

namespace WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class InvoiceController : BaseController
    {
        private readonly IMapper _mapper;

        public InvoiceController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Get the list of ContractorMaterials
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorMaterial
        /// </remarks>
        /// <param name="page">Number of page</param>
        /// <returns>Return ConctractorMaterialVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet("[action]/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<InvoiceListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetInvoiceListQuery { page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contractor material by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractorMaterial/0
        /// </remarks>
        /// <param name="id">Contractor Material Id</param>
        /// <returns>Return ContractorMaterialDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpGet("{id}/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InvoiceDetailsVm>> Get(int id)
        {
            var query = new GetInvoiceDetailsQuery
            {
                id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create Contractor Material
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /contractorMaterial
        /// {
        ///     name: "Test"
        /// }
        /// </remarks>
        /// <param name="createInvoice">CreateContractorMaterialDto object</param>
        /// <returns>Return Contractor Material</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateInvoiceDto createInvoice)
        {
            try
            {
                var command = _mapper.Map<CreateInvoiceCommand>(createInvoice);
                var noteId = await Mediator.Send(command);
                return Ok(noteId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update Contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /contractor
        /// {
        ///     id: 0,
        ///     name: "Test2"
        /// }
        /// </remarks>
        /// <param name="updateInvoice">UpdateContractorDto object</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInvoiceDto updateInvoice)
        {
            var command = _mapper.Map<UpdateInvoiceCommand>(updateInvoice);
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

        /// <summary>
        /// Delete Contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /contractor/0
        /// </remarks>
        /// <param name="id">Contractor Id</param>
        /// <returns>Return NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteInvoiceCommand
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
