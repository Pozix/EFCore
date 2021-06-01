using System;
using System.Collections.Generic;
using System.Text;
using DAL.UserNs.Models;
using MediatR;

namespace DAL.UserNs.Queries
{
    public record GetUserListQuery : IRequest<List<User>>;
}
