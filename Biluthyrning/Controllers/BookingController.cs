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

            var allCars = _carRepository.GetAllCars().Where(x => x.Booked == false && x.ForRent == true);
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
        public IActionResult Create([Bind("Id,Car,Customer,Booking")] BookingVm vm)
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
            Booking booking = _bookingRepository.GetBookingById(id);

            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(Booking booking)
        {

            //Beräknar kundens bonusnivå

            booking.Customer.RentedKm = booking.Customer.RentedKm + booking.Distance;
            booking.Customer.NumberOfRents += 1;


            if (booking.Customer.NumberOfRents < 3)
            {
                booking.Customer.MemberLevel = MemberLevel.Standard;
            }
            if (booking.Customer.NumberOfRents >= 3 && booking.Customer.NumberOfRents < 5)
            {
                booking.Customer.MemberLevel = MemberLevel.Bronze;
            }
            if (booking.Customer.NumberOfRents >= 5)
            {
                booking.Customer.MemberLevel = MemberLevel.Silver;
            }
            if (booking.Customer.NumberOfRents >= 5 && booking.Customer.RentedKm >= 1000)
            {
                booking.Customer.MemberLevel = MemberLevel.Gold;
            }
            //Beräknar bilens status
            booking.Car.Cleaning = true;

            booking.Car.Counter += 1;

            
            if (booking.Car.Counter % 3 == 0)
            {
                booking.Car.Service = true;
            }

            if (booking.Car.DrivenKm > 2000)
            {
                booking.Car.Dispose = true;
            }

            booking.Active = false;
            booking.Car.ForRent = true;
            booking.Car.DrivenKm = booking.Car.DrivenKm + Convert.ToInt32(booking.Distance);

            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(booking.Customer);
                _carRepository.UpdateCar(booking.Car);
                //var car = _carRepository.GetCarById(booking.CarId);
                _bookingRepository.Payment(booking);
                return View("BookingConfirmation", booking);
            }
            return View(booking);
        }
    }
}
