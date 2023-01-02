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
        /// Get the list of Invoices
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /invoice
        /// </remarks>
        /// <param name="page">Number of page</param>
        /// <returns>Return InvoiceVm</returns>
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
        /// Gets the invoice by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /invoice/0
        /// </remarks>
        /// <param name="id">Invoice Id</param>
        /// <returns>Return InvoiceDetailsVm</returns>
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
        /// Create Invoice
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /invoice
        /// {
        ///     name: "Test"
        /// }
        /// </remarks>
        /// <param name="createInvoice">CreateInvoiceDto object</param>
        /// <returns>Return Invoice</returns>
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
        /// Update Invoice
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /invoice
        /// {
        ///     id: 0,
        ///     name: "Test2"
        /// }
        /// </remarks>
        /// <param name="updateInvoice">UpdateInvoiceDto object</param>
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
        /// Delete Invoice
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /invoice/0
        /// </remarks>
        /// <param name="id">Invoice Id</param>
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
