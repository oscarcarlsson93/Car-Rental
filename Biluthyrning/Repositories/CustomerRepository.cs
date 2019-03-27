using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChangesAsync();
        }

        public List<SelectListItem> AllCustomerList(IEnumerable<Customer> allCustomers)
        {
            var listOfCustomers = new List<SelectListItem>();

            foreach (var customer in allCustomers)
            {
                string wholeName = $"{customer.FirstName} {customer.LastName}";
                var x = new SelectListItem() { Text = wholeName, Value = customer.Id.ToString() };
                listOfCustomers.Add(x);
            }

            return listOfCustomers;
        }

        public IEnumerable<Booking> GetAllCustomerBookings(int? id)
        {
            return _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false).Where(m => m.CustomerId == id);

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
           return _context.Customer.ToList();
        }

        public Customer GetCustomerById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
