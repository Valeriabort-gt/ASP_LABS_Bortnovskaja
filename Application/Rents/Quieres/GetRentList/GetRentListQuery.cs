using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Rents.Quieres.GetRentList
{
    public class GetRentListQuery : IRequest<RentListVm>
    {
        public int page { get; set; }
    }
}
