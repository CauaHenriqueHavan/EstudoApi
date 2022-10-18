using estudo.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClienteEntity> Cliente { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            => Database.EnsureCreated();
    }
}
