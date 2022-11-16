using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Organizations.Queres.GetOrganizationList;

namespace WebApplication.Controllers
{
    public class OrganizationController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 246)]
        public async Task<IActionResult> Index()
        {
            var query = new GetOrganizationListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
