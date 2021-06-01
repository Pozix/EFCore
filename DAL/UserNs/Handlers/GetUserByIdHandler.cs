using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL.UserNs.Models;
using DAL.UserNs.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DAL.UserNs.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public GetUserByIdHandler(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                var user = await ctx.Users.AsNoTracking().SingleOrDefaultAsync(o => o.UserId == request.Id, cancellationToken: cancellationToken);
                return user;
            }
        }
    }
}
