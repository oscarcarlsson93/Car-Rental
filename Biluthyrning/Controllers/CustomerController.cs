using Biluthyrning.Data;
using Biluthyrning.Models;
using Biluthyrning.Repositories;
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
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public IActionResult Index()
        {
            var allCustomers = _customerRepository.GetAllCustomers();
            return View(allCustomers);
        }

        public IActionResult AllBookings(int? id)
        {
           //var customer = _customerRepository.GetCustomerById(id);
            var allBookings = _customerRepository.GetAllCustomerBookings(id);
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
                _customerRepository.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", customer);
        }
    }
}
