using System.Collections.Generic;
using customers.management.core.dto;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface ICustomerDetailsService
    {
        /// <summary>
        /// get all base customer info
        /// </summary>
        /// <returns></returns>
        List<CustomerDetails> GetAllCustomerDetails();

        /// <summary>
        /// get all details about customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerDetails GetCustomerDetailsById(int id);

        void SaveCustomerDetails(CustomerDetails customerDetails);

        void DeleteCustomerDetails(CustomerDetails customerDetails);

        Manager GetManagerByDepId(int id);



    }
}
