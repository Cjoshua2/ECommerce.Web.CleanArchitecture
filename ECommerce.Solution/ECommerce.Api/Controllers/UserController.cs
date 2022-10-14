using ECommerce.Application.Users.Queries;
using ECommerce.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
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

        [Route("[action]")]
        [HttpGet]
        public async Task<Result<List<GetUsersModel>>> GetUsers()
        {
            try
            {
                return new Ok<List<GetUsersModel>>(await _mediator.Send(new GetUsersQuery()));
            }
            catch(Exception e)
            {
                return new Error<List<GetUsersModel>>(e.Message);
            }
        }
    }
}
