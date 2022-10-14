using ECommerce.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new User() { Id = 1, Username = "John", Password = "1234" },
                new User() { Id = 2, Username = "Jane", Password = "1234" }
                );
        }
    }
}
