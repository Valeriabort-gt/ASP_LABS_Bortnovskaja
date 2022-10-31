using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, InvoiceListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetInvoiceListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<InvoiceListVm> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var invoiceQuery = await _dbcontext.invoices.ProjectTo<InvoiceLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new InvoiceListVm { invoices = invoiceQuery };
        }
    }
}
