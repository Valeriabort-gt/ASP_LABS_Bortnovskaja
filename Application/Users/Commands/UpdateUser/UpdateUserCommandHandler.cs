using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;
using System.Security.Cryptography;
using System.Text;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IDbContext _dbcontext;
        public UpdateUserCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _dbcontext.Users.FirstOrDefaultAsync(entity => entity.id == request.Id, cancellationToken);

            if (entity.Result == null || entity.Result.id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            string hash;
            if (entity.Result.Password != request.Password)
            {
                using (MD5 md5 = MD5.Create())
                {
                    hash = String.Join("", md5.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));
                }
            }
            else
            {
                hash = entity.Result.Password;
            }

            entity.Result.Login = request.Login;
            entity.Result.Password = hash;
            entity.Result.RoleId = request.RoleId;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
