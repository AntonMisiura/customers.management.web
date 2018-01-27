using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using customers.management.core.Contracts;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
       
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.Add(contact);
        }

        public void EditContact(Contact contact)
        {
            _contactRepository.Edit(contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }
    }
}
