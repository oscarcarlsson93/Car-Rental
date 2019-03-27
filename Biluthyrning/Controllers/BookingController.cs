using Biluthyrning.Data;
using Biluthyrning.Models;
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

        public static decimal baseDayRental = 100;
        public static decimal kmPrice = 10;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
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
                var booking = new Booking();

                booking.Id = new Guid();
                booking.Car = vm.Car;
                booking.CustomerId = vm.Booking.CustomerId;
                booking.PickUpDate = vm.Booking.PickUpDate;

                _context.Add(booking);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", vm);
        }

        public IActionResult Cancel(int? id)
        {
            var xxx = _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false);

            return View(xxx);
        }

        public async Task<IActionResult> Payment(Guid? id)
        {
            var booking = _context.Booking.Include(x => x.Car).Include(z => z.Customer).FirstOrDefault(y => y.Id == id);

            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Booking booking)
        {

            booking.Active = false;
            booking.Car.DrivenKm = booking.Car.DrivenKm + Convert.ToInt32(booking.Distance);

            if (ModelState.IsValid)
            {
                decimal carCost;

                if (booking.Car.CarType == CarType.Small)
                {
                    carCost = baseDayRental * booking.RentedDays;
                    booking.Price = carCost;
                }
                if (booking.Car.CarType == CarType.Van)
                {
                    carCost = decimal.Round((baseDayRental * booking.RentedDays * 1.2m) + (kmPrice * booking.Distance), 2, MidpointRounding.AwayFromZero);
                    booking.Price = carCost;
                }
                if (booking.Car.CarType == CarType.Minibus)
                {
                    carCost = decimal.Round((baseDayRental * booking.RentedDays * 1.7m) + (kmPrice * booking.Distance * 1.5m), 2, MidpointRounding.AwayFromZero);
                    booking.Price = carCost;
                }

                _context.Update(booking.Car);
                _context.Update(booking);
                await _context.SaveChangesAsync();

                return View("BookingConfirmation", booking);
            }
            return View(booking);
        }




    }
}
