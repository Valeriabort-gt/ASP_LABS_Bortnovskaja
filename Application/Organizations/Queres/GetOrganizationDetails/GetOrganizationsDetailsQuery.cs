using MediatR;

namespace Application.Organizations.Queres.GetOrganizationDetails
{
    public class GetOrganizationsDetailsQuery : IRequest<OrganizationDetailsVm>
    {
        public int id { get; set; }
    }
}
