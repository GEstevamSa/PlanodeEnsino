using LP.DbEFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LP.DbEFCore.Repositories
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //domain
            modelBuilder.ApplyConfiguration(new UserMapConfig());
        }
    }
}
