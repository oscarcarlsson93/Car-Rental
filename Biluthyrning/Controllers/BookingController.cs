using Biluthyrning.Data;
using Biluthyrning.Models;
using Biluthyrning.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookingRepository _bookingRepository;


        public static decimal baseDayRental = 100;
        public static decimal kmPrice = 10;

        public BookingController(ApplicationDbContext context, IBookingRepository bookingRepository)
        {
            _context = context;
            _bookingRepository = bookingRepository;
        }


        public IActionResult Index()
        {
            var bookingVm = new BookingVm();

            string[] allCarTypes = Enum.GetNames(typeof(CarType));
            var allCustomers = _context.Customer.ToList();

            var list = new List<SelectListItem>();
            var listOfCustomers = new List<SelectListItem>();

            foreach (var customer in allCustomers)
            {
                string wholeName = $"{customer.FirstName} {customer.LastName}";
                var x = new SelectListItem() { Text = wholeName, Value = customer.Id.ToString() };
                listOfCustomers.Add(x);
            }

            foreach (var x in allCarTypes)
            {
                list.Add(new SelectListItem
                {
                    Text = x
                }
                );
            }
            bookingVm.AllCustomers = listOfCustomers;
            bookingVm.AllCarTypes = list;
            return View(bookingVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Car,Customer,Booking")] BookingVm vm)
        {
            if (ModelState.IsValid)
            {
                _bookingRepository.CreateBooking(vm);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", vm);
        }

        public IActionResult Cancel()
        {
            var allBookings = _bookingRepository.GetAllBookings();

            return View(allBookings);
        }

        public async Task<IActionResult> Payment(Guid? id)
        {
            var booking = _bookingRepository.GetBookingById(id);

            return  View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Booking booking)
        {
            booking.Active = false;
            booking.Car.DrivenKm = booking.Car.DrivenKm + Convert.ToInt32(booking.Distance);

            if (ModelState.IsValid)
            {
                _bookingRepository.Payment(booking);

                _context.Update(booking.Car);
                await _context.SaveChangesAsync();

                return View("BookingConfirmation", booking);
            }
            return View(booking);
        }
    }
}
