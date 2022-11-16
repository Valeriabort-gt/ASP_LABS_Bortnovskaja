using MediatR;
using Domain;

namespace Application.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommand : IRequest
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string email { get; set; }
    }
}
