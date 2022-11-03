using estudo.domain.Entities;
using estudo.domain.Enums;
using estudo.infra.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace estudo.tests.Configurations
{
    public static class DadosFixture
    {   
        public static void MockBanco()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

           var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;

            var context = new AppDbContext();
            
           context.Database.EnsureCreated();
            

            context.Cliente.Add(new ClienteEntity("caua", "henrique", DateTime.Now.AddYears(-19),"131.111.224-48", SituacaoEnum.Ativo));
            context.SaveChanges();
        }
    }
}
