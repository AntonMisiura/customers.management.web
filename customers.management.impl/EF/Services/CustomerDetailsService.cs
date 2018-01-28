﻿using System.Collections.Generic;
using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.dto;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private IUserService _userService;
        private IContactService _contactService;
        private ICustomerService _customerService;
        private IDepartmentService _departmentService;
        private IManagerRepository _managerRepository;

        public CustomerDetailsService(ICustomerService customerService, 
            IUserService userService, 
            IContactService contactService, 
            IDepartmentService departmentService,
            IManagerRepository managerRepository)
        {
            _userService = userService;
            _contactService = contactService;
            _customerService = customerService;
            _departmentService = departmentService;
            _managerRepository = managerRepository;
        }

        public Manager GetManagerByDepId(int id)
        {
            return _managerRepository.GetByDepartmentId(id);
        }

        public List<CustomerDetails> GetAllCustomerDetails()
        {
            return _customerService.GetAll().Select(cust => new CustomerDetails {Customer = cust}).ToList();
        }

        public CustomerDetails GetCustomerDetailsById(int id)
        {
            //inject contact list and users list to customerDetails list
            var departments = new HashSet<Department>();

            foreach (var user in _userService.GetUsersByCustomerId(id))
            {
                if (user.Department.Id != null)
                    user.Department.Manager = _managerRepository.GetByDepartmentId((int) user.Department.Id);

                departments.Add(user.Department);
            }

            var customerDetails = new CustomerDetails
            {
                Customer = _customerService.GetById(id),
                Departments = departments.ToList(),
                Contacts = _contactService.GetByCustomerId(id)
            };

            //get unique departments from users list and inject to customerDetails.Departments
            return customerDetails;
        }

        public CustomerDetails GetCustomerDetailsByUserName(string username)
        {
            var user = _userService.GetByLogin(username);

            var customer = _customerService.GetById(user.CustomerId);

            return new CustomerDetails()
            {
                Customer = customer
            };
        }

        public void SaveCustomerDetails(CustomerDetails customerDetails)
        {
            //TODO: in transaction

            var users = customerDetails.Users;
            var contacts = customerDetails.Contacts;
            var departments = customerDetails.Departments;


        }

        public void DeleteCustomerDetails(CustomerDetails customerDetails)
        {
            //TODO: in transaction
            throw new System.NotImplementedException();
        }
    }
}
