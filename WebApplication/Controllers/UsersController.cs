using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Application.Users.Quieres.GetUsersList;
using Application.Users.Commands.CreateUser;
using Application.Users.Quieres.GetUsersDetail;
using Application.Users.Commands.UpdateUser;
using Application.Users.Commands.DeleteUser;
using WebApplication.Models;
using Domain;

namespace WebApplication.Controllers
{
    public class UsersController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public async Task<IActionResult> Index([FromQuery] int page)
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetUserListQuery
            {
                page = page > 0 ? page : 1,
                url = Request.Host
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserDto createUser)
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateUserCommand
            {
                Login = createUser.Login,
                Password = createUser.Password
            };
            var cvm = await Mediator.Send(query);
            return Redirect("/users");
        }


        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetUserDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Update([FromForm] UpdateUserDto updateUser)
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateUserCommand
            {
                Id = updateUser.Id,
                Login = updateUser.Login,
                Password = updateUser.Password,
                RoleId = updateUser.RoleId
            };
            var vm = await Mediator.Send(query);
            return Redirect("/users");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (CanAccept((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteUserCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/users");
        }

        private bool CanAccept(User user)
        {
            if (user == null || user.RoleId != 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

