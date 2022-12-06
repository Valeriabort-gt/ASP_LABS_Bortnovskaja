using MediatR;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Invoices.Quieres.GetInvoiceList
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, InvoiceListVm>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbcontext;

        public GetInvoiceListQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<InvoiceListVm> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var materials = await _dbcontext.invoices.Skip((request.page - 1) * 15).Take(15).ProjectTo<InvoiceLookupDto>(_mapper.ConfigurationProvider).OrderBy(record => record.id).ToListAsync(cancellationToken);
            var pagesCount = Math.Ceiling(Decimal.Parse((_dbcontext.invoices.Count() / 15.0).ToString()));
            return new InvoiceListVm
            {
                invoices = materials,
                next = request.page + 1 <= pagesCount ? $"https://{request.url.Value}/invoice?page={request.page + 1}" : null,
                back = request.page - 1 > 0 ? $"https://{request.url.Value}/invoice?page={request.page - 1}" : null,
                pagesCount = (int)pagesCount

            };
        }
    }
}
