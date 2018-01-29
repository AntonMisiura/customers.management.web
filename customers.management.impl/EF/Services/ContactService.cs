using System.Collections.Generic;
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

        public List<Contact> GetByCustomerId(int id)
        {
            return _contactRepository.GetByCustomerId(id);
        }

        public void SaveContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                if (contact.Id == null)
                {
                    _contactRepository.Add(contact);
                }
                else
                {
                    _contactRepository.Edit(contact);
                }
            }
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }

        public void DeleteContacts(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                if (contact.Id != null) _contactRepository.Delete((int) contact.Id);
            }
        }
    }
}
