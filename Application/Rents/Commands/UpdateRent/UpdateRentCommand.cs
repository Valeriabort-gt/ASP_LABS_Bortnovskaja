using MediatR;
using Domain;

namespace Application.Rents.Commands.UpdateRent
{
    public class UpdateRentCommand : IRequest
    {
        public int id { get; set; }
        public int roomID { get; set; }
        public int organizationID { get; set; }
        public DateTime entryDate { get; set; }
        public DateTime exitDate { get; set; }
    }
}
