using System;
using System.Collections.Generic;
using System.Text;
using DAL.UserNs.Models;
using MediatR;

namespace DAL.UserNs.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;
}
