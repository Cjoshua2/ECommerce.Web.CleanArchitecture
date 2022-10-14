using ECommerce.Application.Contract;
using ECommerce.Application.Users.Queries;
using ECommerce.Domain.User;
using MediatR;

namespace ECommerce.Application.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<GetUsersModel>>
    {
        private readonly IQueryDatabaseService<User> _queryDatabase;
        public GetUsersHandler(IQueryDatabaseService<User> queryDatabase)
        {
            _queryDatabase = queryDatabase;
        }
        public async Task<List<GetUsersModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _queryDatabase.GetAll();

            var users = result.Select(user => new GetUsersModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            }).ToList();

            return users;
        }
    }
}
