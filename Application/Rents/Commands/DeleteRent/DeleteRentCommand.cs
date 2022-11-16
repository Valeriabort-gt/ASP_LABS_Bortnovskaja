using MediatR;

namespace Application.Rents.Commands.DeleteRent
{
    public class DeleteRentCommand : IRequest
    {
        public int id { get; set; }
    }
}
