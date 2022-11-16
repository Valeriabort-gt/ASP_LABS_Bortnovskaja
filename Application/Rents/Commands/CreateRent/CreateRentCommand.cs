using MediatR;
using Domain;

namespace Application.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<Rent>
    {
        public Room room { get; set; }
        public Organization organization  { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }
    }
}
