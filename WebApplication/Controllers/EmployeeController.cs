using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Employees.Quieres.GetEmployeeList;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 246)]
        public async Task<IActionResult> Index()
        {
            var query = new GetEmployeeListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
