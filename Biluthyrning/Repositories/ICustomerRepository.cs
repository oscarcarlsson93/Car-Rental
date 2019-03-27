using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        List<SelectListItem> AllCustomerList(IEnumerable<Customer> allCustomers);



        //void UpdateCustomer(Customer customer);
        //void RemoveCustomer(Customer customer);

    }
}
