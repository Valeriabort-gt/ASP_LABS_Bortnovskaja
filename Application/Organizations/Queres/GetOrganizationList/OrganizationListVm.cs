namespace Application.Organizations.Queres.GetOrganizationList
{
    public class OrganizationListVm
    {
        public IList<OrganizationLookupDto> organizations { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
