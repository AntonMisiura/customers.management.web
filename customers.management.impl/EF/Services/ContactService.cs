﻿using System.Collections.Generic;
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
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    if (contact.Id == 0)
                    {
                        _contactRepository.Add(contact);
                    }
                    else
                    {
                        _contactRepository.Edit(contact);
                    }
                }

                _contactRepository.Save();
            }
        }

        public void DeleteContacts(List<Contact> contacts)
        {
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    _contactRepository.Delete((int)contact.Id);
                }

                _contactRepository.Save();
            }
        }
    }
}
