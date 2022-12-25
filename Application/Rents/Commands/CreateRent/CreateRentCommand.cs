using MediatR;
using Domain;

namespace Application.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<Rent>
    {
        public int roomID { get; set; }
        public int organizationID  { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }
    }
}
