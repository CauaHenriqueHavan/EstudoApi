using Microsoft.EntityFrameworkCore;

namespace estudo.domain.Interfaces.Service
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        Task CommitAsync();
    }
}
