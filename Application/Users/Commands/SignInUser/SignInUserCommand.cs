using Domain;
using MediatR;

namespace Application.Users.Commands.SignInUser
{
    public class SignInUserCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
