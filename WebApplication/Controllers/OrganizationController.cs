using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Application.Organizations.Queres.GetOrganizationList;
using Application.Organizations.Queres.GetOrganizationSearchList;
using Application.Organizations;
using Application.Organizations.Commands.UpdateOrganization;
using Application.Organizations.Commands.CreateOrganization;
using Application.Organizations.Commands.DeleteOrganization;
using Application.Organizations.Queres.GetOrganizationDetails;
using WebApplication.Models;
using Domain;
using System.Dynamic;
using Application.Users.Quieres.GetUsersList;

namespace WebApplication.Controllers
{
    public class OrganizationController : Controller
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
            var query = new GetOrganizationListQuery { page = page > 0 ? page : 1, url = Request.Host };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Search([FromQuery] string searchString, [FromQuery] int page)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            Response.Cookies.Append("lastSearch", searchString);
            var query = new GetOrganizationSearchListQuery
            {
                searchText = searchString,
                url = Request.Host,
                page = page > 0 ? page : 1,
            };
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
        public async Task<IActionResult> Create([FromForm] CreateOrganizationDto createOrganization)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateOrganizationCommand
            {
                name = createOrganization.name,
                email = createOrganization.email
            };
            var vm = await Mediator.Send(query);
            return Redirect("/organization");
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetOrganizationsDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateOrganizationDto updateOrganization)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateOrganizationCommand
            {
                id = updateOrganization.id,
                name = updateOrganization.name,
                email = updateOrganization.email
            };
            var vm = await Mediator.Send(query);
            return Redirect("/organization");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteOrganizationCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/organization");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}
