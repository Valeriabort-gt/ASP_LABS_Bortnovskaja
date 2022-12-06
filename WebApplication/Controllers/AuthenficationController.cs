using Microsoft.AspNetCore.Mvc;
using MediatR;
using WebApplication.Models;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.SignInUser;

namespace WebApplication.Controllers
{
    public class AuthenficationController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm] SignUpUserDto signUpUser)
        {
            var query = new SignInUserCommand
            {
                Login = signUpUser.Login,
                Password = signUpUser.Password
            };
            var vm = await Mediator.Send(query);
            Response.Cookies.Append("token", vm);
            return Redirect("/");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] SignUpUserDto signUpUser)
        {
            var query = new CreateUserCommand
            {
                Login = signUpUser.Login,
                Password = signUpUser.Password
            };
            var vm = await Mediator.Send(query);
            return Redirect("/authenfication/SignIn");
        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            return Redirect("/account");
        }
    }
}

