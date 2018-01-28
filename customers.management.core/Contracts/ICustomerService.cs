using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface ICustomerService
    {
        /// <summary>
        /// get all customers
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAll();

        /// <summary>
        /// get customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer GetById(int id);

        /// <summary>
        /// add customer
        /// </summary>
        /// <param name="customer"></param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// edit customer
        /// </summary>
        /// <param name="customer"></param>
        void EditCustomer(Customer customer);

        /// <summary>
        /// delete customer by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteCustomer(int id);
    }
}
