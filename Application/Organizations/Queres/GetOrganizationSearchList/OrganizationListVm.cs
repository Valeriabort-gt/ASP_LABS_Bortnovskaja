using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Organizations.Queres.GetOrganizationSearchList
{
    public class OrganizationListVm
    {
        public IList<OrganizationLookupDto> organizations { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
