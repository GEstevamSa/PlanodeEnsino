using LP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LP.DbEFCore.Mappings
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(b => b.Id);
            builder.Property(b => b.Login).HasColumnName("Login");
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.LastLogin).HasColumnName("LastLogin");
        }
    }
}
