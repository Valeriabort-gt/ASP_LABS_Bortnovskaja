﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Organizations.Queres.GetOrganizationSearchList
{
    public class GetOrganizationSearchListQuery : IRequest<OrganizationListVm>
    {
        public string searchText { get; set; }
        
    }
}
