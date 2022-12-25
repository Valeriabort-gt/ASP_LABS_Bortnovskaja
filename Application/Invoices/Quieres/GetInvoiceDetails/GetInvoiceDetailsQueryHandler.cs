using MediatR;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;
using AutoMapper.QueryableExtensions;

namespace Application.Invoices.Quieres.GetInvoiceDetails
{
    public class GetInvoiceDetailsQueryHandler : IRequestHandler<GetInvoiceDetailsQuery, InvoiceDetailsVm>
    {
        private readonly IDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetInvoiceDetailsQueryHandler(IDbContext dbContext, IMapper mapper) => (_dbcontext, _mapper) = (dbContext, mapper);

        public async Task<InvoiceDetailsVm> Handle(GetInvoiceDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.invoices.ProjectTo<InvoiceDetailsVm>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(invoice => invoice.id == request.id, cancellationToken);

            if (entity == null || entity.id != request.id)
            {
                throw new NotFoundException(nameof(Invoice), request.id);
            }

            return _mapper.Map<InvoiceDetailsVm>(entity);
        }
    }
}
