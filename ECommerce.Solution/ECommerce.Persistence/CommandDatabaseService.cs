using ECommerce.Application.Contract;
using ECommerce.Domain.User;
using ECommerce.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence
{
    public class CommandDatabaseService : DbContext, ICommandDatabaseService
    {
        private readonly IConfiguration _configuration;
        public CommandDatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; } = null!;

        public void Save()
        {
            this.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = _configuration.GetConnectionString("DBConnectionString");

            builder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new UserConfiguration().Configure(builder.Entity<User>());
        }
    }
}
