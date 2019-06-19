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
            booking.CarId = vm.Booking.CarId;
            booking.CustomerId = vm.Booking.CustomerId;
            booking.PickUpDate = vm.Booking.PickUpDate;

            _context.Add(booking);
            _context.SaveChanges();
        }

        public IOrderedEnumerable<Booking> GetAllBookings()
        {
            return _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false);
        }

        public Booking GetBookingById(Guid? id)
        {
            return _context.Booking.Include(x => x.Car).Include(z => z.Customer).FirstOrDefault(y => y.Id == id);
        }





        //Uträkningar, ska flyttas till en egen klass

        public void Payment(Booking booking)
        {
            decimal carCost;

            //Standard

            if (booking.Customer.MemberLevel == MemberLevel.Standard)
            {
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
            }

            //Bronze

            if (booking.Customer.MemberLevel == MemberLevel.Bronze)
            {
                var baseDayRental = 50;
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
            }

            //Silver

            if (booking.Customer.MemberLevel == MemberLevel.Silver)
            {
                var baseDayRental = 50;

                if (booking.RentedDays <= 2)
                {

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

                }

                if (booking.RentedDays == 3)
                {
                    if (booking.Car.CarType == CarType.Small)
                    {
                        carCost = baseDayRental * (booking.RentedDays - 1);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Van)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 1) * 1.2m) + (kmPrice * booking.Distance), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Minibus)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 1) * 1.7m) + (kmPrice * booking.Distance * 1.5m), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                }

                if (booking.RentedDays >= 4)
                {
                    if (booking.Car.CarType == CarType.Small)
                    {
                        carCost = baseDayRental * (booking.RentedDays - 2);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Van)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 2) * 1.2m) + (kmPrice * booking.Distance), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Minibus)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 2) * 1.7m) + (kmPrice * booking.Distance * 1.5m), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                }
            }


            //Gold

            if (booking.Customer.MemberLevel == MemberLevel.Gold)
            {
                var baseDayRental = 50;

                booking.Distance = booking.Distance - 20;

                if (booking.RentedDays <= 2)
                {

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

                }

                if (booking.RentedDays == 3)
                {
                    if (booking.Car.CarType == CarType.Small)
                    {
                        carCost = baseDayRental * (booking.RentedDays - 1);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Van)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 1) * 1.2m) + (kmPrice * booking.Distance), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Minibus)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 1) * 1.7m) + (kmPrice * booking.Distance * 1.5m), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                }

                if (booking.RentedDays >= 4)
                {
                    if (booking.Car.CarType == CarType.Small)
                    {
                        carCost = baseDayRental * (booking.RentedDays - 2);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Van)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 2) * 1.2m) + (kmPrice * booking.Distance), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                    if (booking.Car.CarType == CarType.Minibus)
                    {
                        carCost = decimal.Round((baseDayRental * (booking.RentedDays - 2) * 1.7m) + (kmPrice * booking.Distance * 1.5m), 2, MidpointRounding.AwayFromZero);
                        booking.Price = carCost;
                    }
                }
            }


            booking.Car.Booked = false;

            _context.Update(booking);
            _context.Update(booking.Car);
            _context.SaveChanges();
        }
    }
}
