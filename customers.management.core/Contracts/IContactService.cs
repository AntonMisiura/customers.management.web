using System;
using System.Collections.Generic;
using System.Text;
using customers.management.core.Entities;

namespace customers.management.core.Contracts
{
    public interface IContactService
    {
        List<Contact> GetByCustomerId(int id);

        /// <summary>
        /// add contact
        /// </summary>
        /// <param name="contact"></param>
        void AddContact(Contact contact);

        /// <summary>
        /// edit contact
        /// </summary>
        /// <param name="contact"></param>
        void EditContact(Contact contact);

        /// <summary>
        /// delete contact by its id
        /// </summary>
        /// <param name="id"></param>
        void DeleteContact(int id);
    }
}
