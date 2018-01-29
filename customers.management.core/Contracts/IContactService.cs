using System.Collections.Generic;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IContactService
    {
        /// <summary>
        /// get contacts by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Contact> GetByCustomerId(int id);

        /// <summary>
        /// edit and delete contacts
        /// </summary>
        /// <param name="contacts"></param>
        void SaveContacts(List<Contact> contacts);

        /// <summary>
        /// delete contact by its id
        /// </summary>
        /// <param name="id"></param>
        void DeleteContact(int id);

        /// <summary>
        /// delete list of contacts
        /// </summary>
        /// <param name="contacts"></param>
        void DeleteContacts(List<Contact> contacts);
    }
}
