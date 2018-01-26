using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace customers.management.core.Contracts
{
    public interface IRepository<T>
    {
        /// <summary>
        /// get certain entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// get all items
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// add certain entity
        /// </summary>
        /// <param name="t"></param>
        void Add(T t);

        /// <summary>
        /// edit certain entity
        /// </summary>
        /// <param name="t"></param>
        void Edit(T t);
        
        /// <summary>
        /// save changes
        /// </summary>
        void Save();

        /// <summary>
        /// delete certain entity by id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
