using MediatR;

namespace Application.Rents.Quieres.GetRentDetails
{
    public class GetRentDetailsQuery : IRequest<RentDetailsVm>
    {
        public int id { get; set; }
    }
}
