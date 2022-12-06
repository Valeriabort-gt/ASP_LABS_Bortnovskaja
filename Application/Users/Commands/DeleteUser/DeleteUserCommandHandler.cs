using MediatR;
using Application.Interfaces;
using Application.Common.Exceptions;
using Domain;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDbContext _dbcontext;
        public DeleteUserCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Users.FindAsync(new object[] { request.id }, cancellationToken);

            if (entity == null || entity.id != entity.id)
            {
                throw new NotFoundException(nameof(Users), request.id);
            }

            _dbcontext.Users.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
