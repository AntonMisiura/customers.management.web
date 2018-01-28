using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Add(T t)
        {
            if (t != null)
            {
                Context.Set<T>().Add(t);
            }

            Save();
        }

        public void Edit(T t)
        {
            Context.Set<T>().Update(t);

            Save();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Context.Set<T>().Remove(entity);
                Save();
            }
            catch (DbException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
