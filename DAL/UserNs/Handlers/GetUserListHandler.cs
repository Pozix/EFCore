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
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;

        public GetUserListHandler(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            using (var ctx = _factory.CreateDbContext())
            {
                return await ctx.Users.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
