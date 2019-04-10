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
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;


        public static decimal baseDayRental = 100;
        public static decimal kmPrice = 10;

        public BookingController(IBookingRepository bookingRepository, ICustomerRepository customerRepository, ICarRepository carRepository)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _carRepository = carRepository;
        }


        public IActionResult Index()
        {
            

            var bookingVm = new BookingVm();

            var allCustomers = _customerRepository.GetAllCustomers();
            var listOfCustomers = _customerRepository.AllCustomerList(allCustomers);

            var allCars = _carRepository.GetAllCars().Where( x => x.Booked == false);
            var listOfCars = _carRepository.AllCarList(allCars);

            
            bookingVm.AllCustomers = listOfCustomers;
            bookingVm.AllCars = listOfCars;
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
                _carRepository.UpdateCarStatus(vm.Booking.CarId);
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
            if (booking.RentedDays < 1)
            {

                return View(booking);
            }
            else


                booking.Active = false;
            booking.Car.DrivenKm = booking.Car.DrivenKm + Convert.ToInt32(booking.Distance);

            if (ModelState.IsValid)
            {
                _bookingRepository.Payment(booking);
                return View("BookingConfirmation", booking);
            }
            return View(booking);
        }
    }
}
