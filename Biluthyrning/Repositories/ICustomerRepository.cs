using Biluthyrning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Repositories
{
    public interface ICustomerRepository
    {
            IEnumerable<Customer> GetAllCustomers();

            Customer GetCustomerById(int? id);

        IEnumerable<Booking> GetAllCustomerBookings(int? id);

        void AddCustomer(Customer customer);


        //void UpdateCustomer(Customer customer);
        //void RemoveCustomer(Customer customer);

    }
}
