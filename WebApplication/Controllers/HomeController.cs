using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 246)]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}