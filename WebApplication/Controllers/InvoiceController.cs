using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Invoices.Quieres.GetInvoiceList;

namespace WebApplication.Controllers
{
    public class InvoiceController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 246)]
        public async Task<IActionResult> Index()
        {
            var query = new GetInvoiceListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
