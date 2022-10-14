using ECommerce.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Contract
{
    public interface ICommandDatabaseService
    {
        DbSet<User> User { get; set; }
        void Save();
    }
}
