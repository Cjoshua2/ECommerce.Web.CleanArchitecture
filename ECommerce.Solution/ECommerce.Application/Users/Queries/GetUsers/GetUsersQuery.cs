using ECommerce.Application.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly IDatabaseService _database;
        public GetUsersQuery(IDatabaseService database)
        {
            _database = database;
        }

        public async Task<List<GetUsersModel>> Execute()
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
