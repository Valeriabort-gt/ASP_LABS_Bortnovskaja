using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand>
    {
        private readonly IDbContext _dbcontext;

        public UpdateInvoiceCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.invoices.FirstOrDefaultAsync(record => record.id == request.id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.id)
            {
                throw new NotFoundException(nameof(Invoice), request.id);
            }

            entity.Result.createDate = request.createDate;
            entity.Result.number = request.number;
            entity.Result.organizationID = request.organizationID;
            entity.Result.roomID = request.roomID;
            entity.Result.puySum = request.puySum;
            entity.Result.payDate = request.payDate;
            entity.Result.employeeID = request.employeeID;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
