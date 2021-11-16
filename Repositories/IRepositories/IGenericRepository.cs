using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetByID(Guid id);
        void Insert(T entity);
        void Delete(Guid id);
        void Update(T entity);
        void Save();

    }
}
