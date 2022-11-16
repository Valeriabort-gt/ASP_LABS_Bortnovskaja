using MediatR;

namespace Application.Rents.Quieres.GetRentList
{
    public class GetRentListQuery : IRequest<RentListVm>
    {
        public string cacheKey { get; set; }
    }
}
