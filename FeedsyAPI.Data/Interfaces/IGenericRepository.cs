using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeedsyAPI.Data.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(object id);
    Task<bool> SaveChangesAsync();
}