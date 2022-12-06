using Domain;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
