using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var allCustomers = _context.Customer.ToList();

            return View(allCustomers);
        }

        public IActionResult AllBookings(int? id)
        {
            var allBookings = _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false).Where(m => m.CustomerId == id);
            return View(allBookings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", customer);
        }
    }
}
