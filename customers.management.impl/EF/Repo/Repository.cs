using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using customers.management.core.Contracts;

namespace customers.management.impl.EF.Repo
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected CustomersContext Context { get; private set; }

        public Repository(CustomersContext context)
        {
            Context = context;
        }

        public T GetById(CancellationToken token, int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> GetByCustomerId(CancellationToken token, int id)
        {
            var selected = Context.Set<T>().Where(e => e.Id == id);

            return selected;
        }

        public IEnumerable<T> GetAll(CancellationToken token)
        {
            return Context.Set<T>().ToList();
        }

        public void Add(CancellationToken token, T t)
        {
            if (t != null)
            {
                Context.Set<T>().Add(t);
            }

            Save(token);
        }

        public void Edit(CancellationToken token, T t)
        {
            var editable = GetById(token, t.Id);
            Context.Set<T>().Update(editable);

            Save(token);
        }

        public void Delete(CancellationToken token, int id)
        {
            var entity = GetById(token, id);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Context.Set<T>().Remove(entity);
                Save(token);
            }
            catch (DbException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public void Save(CancellationToken token)
        {
            Context.SaveChanges();
        }
    }
}
