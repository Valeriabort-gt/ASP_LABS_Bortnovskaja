namespace Application.Organizations.Queres.GetOrganizationList
{
    public class OrganizationListVm
    {
        public IList<OrganizationLookupDto> organizations { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
