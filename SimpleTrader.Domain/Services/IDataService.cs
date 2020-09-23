using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(int Id);
        Task<T> Create(T entity);
        Task<T> Update(int Id, T entity);
        Task<bool> Delete(int id);
    }
}
