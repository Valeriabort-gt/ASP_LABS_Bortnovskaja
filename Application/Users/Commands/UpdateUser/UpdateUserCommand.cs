using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
