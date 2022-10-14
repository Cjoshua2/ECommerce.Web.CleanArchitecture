using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Users.Queries.GetUsers
{
    public interface IGetUsersQuery
    {
        Task<List<GetUsersModel>> Execute();
    }
}
