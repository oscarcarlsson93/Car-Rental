using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.EntityFrameworkCore;

namespace Biluthyrning.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public static decimal baseDayRental = 100;
        public static decimal kmPrice = 10;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBooking(BookingVm vm)
        {
            var booking = new Booking();

            booking.Id = new Guid();
            booking.Car = vm.Car;
            booking.CustomerId = vm.Booking.CustomerId;
            booking.PickUpDate = vm.Booking.PickUpDate;

            _context.Add(booking);
            _context.SaveChangesAsync();
        }

        public IOrderedEnumerable<Booking> GetAllBookings()
        {
            return _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false);
        }

        public Booking GetBookingById(Guid? id)
        {
            return _context.Booking.Include(x => x.Car).Include(z => z.Customer).FirstOrDefault(y => y.Id == id);
        }

        public void Payment(Booking booking)
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
            _context.Update(booking);
            _context.Update(booking.Car);
            _context.SaveChangesAsync();
        }
    }
}
