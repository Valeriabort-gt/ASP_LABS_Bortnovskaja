namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class InvoiceListVm
    {
        public IList<InvoiceLookupDto> invoices { get; set; }
        public int totalElements { get; set; }
        public int pagesCount { get; set; }
    }
}
