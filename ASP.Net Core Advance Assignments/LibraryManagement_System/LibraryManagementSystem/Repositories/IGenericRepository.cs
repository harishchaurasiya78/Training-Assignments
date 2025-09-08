using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
