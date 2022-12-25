using MediatR;
using Domain;

namespace Application.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommand : IRequest<Organization>
    {
        public string name { get; set; }
        public string email { get; set; }
    }
}
