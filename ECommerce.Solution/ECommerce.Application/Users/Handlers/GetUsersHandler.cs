using ECommerce.Application.Contract;
using ECommerce.Application.Users.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<GetUsersModel>>
    {
        private readonly IDatabaseService _database;
        public GetUsersHandler(IDatabaseService database)
        {
            _database = database;
        }
        public async Task<List<GetUsersModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _database.Users.Select(user => new GetUsersModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            }).ToListAsync();
        }
    }
}
