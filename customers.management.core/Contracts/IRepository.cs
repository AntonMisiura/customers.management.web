using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace customers.management.core.Contracts
{
    public interface IRepository<T>
    {
        T GetById(CancellationToken token, int id);

        IEnumerable<T> GetByCustomerId(CancellationToken token, int id);

        IEnumerable<T> GetAll(CancellationToken token);

        void Add(CancellationToken token, T t);

        void Edit(CancellationToken token, T t);
        
        void Save(CancellationToken token);

        void Delete(CancellationToken token, int id);
    }
}
