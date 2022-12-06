namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class InvoiceListVm
    {
        public IList<InvoiceLookupDto> invoices { get; set; }
        public string next { get; set; }
        public string back { get; set; }
        public int pagesCount { get; set; }
    }
}
