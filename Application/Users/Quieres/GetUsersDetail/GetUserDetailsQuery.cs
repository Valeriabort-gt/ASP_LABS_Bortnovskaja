using MediatR;

namespace Application.Users.Quieres.GetUsersDetail
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public int id { get; set; }
    }
}
