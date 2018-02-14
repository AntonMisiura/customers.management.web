using System;
using System.Collections.Generic;
using System.Linq;
using customers.management.core.Contracts;
using customers.management.core.dto;
using customers.management.core.Entities;

namespace customers.management.impl.EF.Services
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private CustomersContext _context;
        private IUserService _userService;
        private IContactService _contactService;
        private ICustomerService _customerService;
        private IDepartmentService _departmentService;
        private IManagerRepository _managerRepository;

        public CustomerDetailsService(ICustomerService customerService,
            IUserService userService,
            IContactService contactService,
            IDepartmentService departmentService,
            IManagerRepository managerRepository, 
            CustomersContext context)
        {
            _context = context;
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

        public void AddCustomerDetailses(CustomerDetails customerDetails)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _customerService.AddCustomer(customerDetails.Customer);

                    var customerId = customerDetails.Customer.Id;

                    foreach (var contact in customerDetails.Contacts)
                    {
                        contact.CustomerId = customerId;
                    }

                    foreach (var user in customerDetails.Users)
                    {
                        user.CustomerId = customerId;
                    }
                    
                    _contactService.SaveContacts(customerDetails.Contacts);

                    _departmentService.SaveDepartments(customerDetails.Departments);

                    _userService.SaveUsers(customerDetails.Users);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<CustomerDetails> GetAllCustomerDetails()
        {
            return _customerService.GetAll().Select(cust => new CustomerDetails { Customer = cust }).ToList();
        }

        public CustomerDetails GetCustomerDetailsById(int id)
        {
            //TODO: need to fix, if user have no department then i cant get departments for customer
            var departments = new HashSet<Department>();

            foreach (var user in _userService.GetUsersByCustomerId(id))
            {
                user.Department.Manager = _managerRepository.GetByDepartmentId(user.Department.Id);

                departments.Add(user.Department);
            }

            var customerDetails = new CustomerDetails
            {
                Customer = _customerService.GetById(id),
                Departments = departments.ToList(),
                Contacts = _contactService.GetByCustomerId(id)
            };

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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var users = customerDetails.Users;
                    var contacts = customerDetails.Contacts;
                    var departments = customerDetails.Departments;

                    _contactService.SaveContacts(contacts);

                    _departmentService.SaveDepartments(departments);
                    _userService.SaveUsers(users);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteCustomerDetails(CustomerDetails customerDetails)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var users = customerDetails.Users;
                    var contacts = customerDetails.Contacts;
                    var departments = customerDetails.Departments;

                    _contactService.DeleteContacts(contacts);

                    _userService.DeleteUsers(users);
                    _departmentService.DeleteDepartments(departments);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
