using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.UserNs.Commands;
using DAL.UserNs.Handlers;
using DAL.UserNs.Models;
using DAL.UserNs.Queries;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            var model = new InsertUserCommand(user.Name, user.Address, user.Contact);
            return await _mediator.Send(model);
        }
    }
}
