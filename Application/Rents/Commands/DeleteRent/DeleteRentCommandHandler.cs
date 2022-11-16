using MediatR;
using Application.Interfaces;
using Domain;
using Application.Common.Exceptions;

namespace Application.Rents.Commands.DeleteRent
{
    public class DeleteRentCommandHandler : IRequestHandler<DeleteRentCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeleteRentCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.rents.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Rent), request.id);
            }

            _dbcontext.rents.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
