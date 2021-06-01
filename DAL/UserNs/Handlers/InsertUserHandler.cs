using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DAL.UserNs.Commands;
using DAL.UserNs.Models;
using DAL.UserNs.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DAL.UserNs.Handlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, User>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public InsertUserHandler(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<User> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                var user = new User
                {
                    Address = request.Address,
                    Contact = request.Contact,
                    Name = request.Name
                };
                await ctx.Users.AddAsync(user, cancellationToken);
                if (await ctx.SaveChangesAsync(cancellationToken) > 0)
                    return user;
                return new User();
            }
        }
    }
}