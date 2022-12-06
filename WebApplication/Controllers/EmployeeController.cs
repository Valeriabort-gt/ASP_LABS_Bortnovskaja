using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Employees.Quieres.GetEmployeeList;
using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Quieres.GetEmployeeDetails;
using Application.Employees.Commands.DeleteEmployee;
using WebApplication.Models;
using Domain;
using System.Dynamic;
using Application.Employees.Commands.UpdateEmployee;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
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
            var query = new GetEmployeeListQuery { page = page > 0 ? page : 1, url = Request.Host };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeDto createEmployee)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateEmployeeCommand
            {
                name = createEmployee.name,
                surname = createEmployee.surname
            };
            var vm = await Mediator.Send(query);
            return Redirect("/employee");
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetEmployeeDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeDto updateEmployee)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateEmployeeCommand
            {
                id = updateEmployee.id,
                name = updateEmployee.name,
                surname = updateEmployee.surname
            };
            var vm = await Mediator.Send(query);
            return Redirect("/employee");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteEmployeeCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/employee");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}

