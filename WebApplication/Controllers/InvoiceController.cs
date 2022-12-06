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

namespace WebApplication.Controllers
{
    public class InvoiceController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public async Task<IActionResult> Index([FromQuery] int page)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetInvoiceListQuery { page = page > 0 ? page : 1, url = Request.Host };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var roomQuery = new GetRoomListQuery();
            var roomListVm = await Mediator.Send(roomQuery);
            var orgQuery = new GetOrganizationListQuery();
            var orgListVm = await Mediator.Send(orgQuery);
            var employeeQuery = new GetEmployeeListQuery();
            var employeeListVm = await Mediator.Send(employeeQuery);
            dynamic model = new ExpandoObject();
            model.rooms = roomListVm.rooms;
            model.organizations = orgListVm.organizations;
            model.employees = employeeListVm.employees;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateInvoiceDto createInvoice)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateInvoiceCommand
            {
                createDate = createInvoice.createDate,
                number = createInvoice.number,
                organization = new Organization { id = createInvoice.organization },
                room = new Room { id = createInvoice.room },
                puySum = createInvoice.puySum,
                payDate = createInvoice.payDate,
                employee = new Employee { id = createInvoice.employee }
            };
            var vm = await Mediator.Send(query);
            return Redirect("/invoice");
        }
        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var detailQuery = new GetInvoiceDetailsQuery
            {
                id = id
            };
            var detailVm = await Mediator.Send(detailQuery);
            var roomQuery = new GetRoomListQuery();
            var roomListVm = await Mediator.Send(roomQuery);
            var orgQuery = new GetOrganizationListQuery();
            var orgListVm = await Mediator.Send(orgQuery);
            var employeeQuery = new GetEmployeeListQuery();
            var employeeListVm = await Mediator.Send(employeeQuery);
            dynamic model = new ExpandoObject();
            model.detail = detailVm;
            model.rooms = roomListVm.rooms;
            model.organizations = orgListVm.organizations;
            model.employees = employeeListVm.employees;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateInvoiceDto updateInvoice)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateInvoiceCommand
            {
                id = updateInvoice.id,
                createDate = updateInvoice.createDate,
                number = updateInvoice.number,
                organizationID = updateInvoice.organization,
                roomID = updateInvoice.room,
                puySum = updateInvoice.puySum,
                payDate = updateInvoice.payDate,
                employeeID = updateInvoice.employee
            };
            var vm = await Mediator.Send(query);
            return Redirect("/invoice");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteInvoiceCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/invoice");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}
