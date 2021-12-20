using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IGenericRepository<T> : IDisposable
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetByID(Guid id);
        Task<T> Insert(T entity);
        Task<int> Delete(Guid id);
        Task<T> Update(T entity);
        Task<int> Save();

    }
}
