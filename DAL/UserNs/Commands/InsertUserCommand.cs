using DAL.UserNs.Models;
using MediatR;

namespace DAL.UserNs.Commands
{
    public record InsertUserCommand(string Name, string Address, string Contact) : IRequest<User>;
}