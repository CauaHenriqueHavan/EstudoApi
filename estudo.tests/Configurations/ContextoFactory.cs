using Microsoft.EntityFrameworkCore;

namespace estudo.tests.Configurations
{
    public static class ContextoFactory
    {
        public static T CriarContexto<T>() where T : DbContext
        {
            DbContextOptionsBuilder<T> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseInMemoryDatabase("T");
            return (T)Activator.CreateInstance(typeof(T), dbContextOptionsBuilder.Options);
        }
    }
}
