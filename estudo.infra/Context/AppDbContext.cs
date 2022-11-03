using estudo.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<ProdutoEntity> Produto { get; set; }
        public DbSet<FornecedorEntity> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=local.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
