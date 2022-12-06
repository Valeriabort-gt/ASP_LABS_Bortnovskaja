using MediatR;
using Domain;
using Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain.JWTModels;

namespace Application.Users.Commands.SignInUser
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, string>
    {
        private readonly IDbContext _dbcontext;
        public SignInUserCommandHandler(IDbContext dbContext) => _dbcontext = dbContext;
        public async Task<string> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            string hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = String.Join("", md5.ComputeHash(Encoding.UTF8.GetBytes(request.Password)));
            }

            var entity = await _dbcontext.Users.FirstOrDefaultAsync(user => (user.Login == request.Login && user.Password == hash), cancellationToken);

            if (entity == null || entity.Login != request.Login || entity.Password != hash)
            {
                throw new NotFoundException(nameof(User), request.Login);
            }

            var jsonHeader = JsonSerializer.Serialize(new Header { alg = "HS256", typ = "JWT" });
            string codeHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonHeader));

            var expDate = ConvertDateTimeToInt32(DateTime.Now.AddDays(30));
            var jsonPayload = JsonSerializer.Serialize(new Payload { id = entity.id, exp = expDate });
            string codePayload = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonPayload));

            var jsonSignature = JsonSerializer.Serialize(new Signature { key = "I love C Sharp" });
            var codeSecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonSignature));

            var token = String.Join(".", codeHeader, codePayload, codeSecret);

            return token;
        }

        private int ConvertDateTimeToInt32(DateTime dt)
        {
            return (int)(dt - new DateTime(2017, 1, 1)).TotalSeconds;
        }
        private DateTime ConvertInt32ToDateTime(int i)
        {
            return new DateTime(2017, 1, 1).AddSeconds(i);
        }
    }
}
