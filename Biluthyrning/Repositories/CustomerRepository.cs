using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biluthyrning.Data;
using Biluthyrning.Models;
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
