using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Organizations.Queres.GetOrganizationList
{
    public class GetOrganizationListQuery : IRequest<OrganizationListVm>
    {
        
        public int page { get; set; }
        
    }
}
