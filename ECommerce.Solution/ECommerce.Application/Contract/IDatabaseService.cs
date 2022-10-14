using ECommerce.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Contract
{
    public interface IDatabaseService
    {
        DbSet<User> Users { get; set; }
        void Save();
    }
}
