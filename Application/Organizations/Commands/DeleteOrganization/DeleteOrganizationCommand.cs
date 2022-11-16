using MediatR;

namespace Application.Organizations.Commands.DeleteOrganization
{
    public class DeleteOrganizationCommand : IRequest
    {
        public int id { get; set; } 
    }
}
