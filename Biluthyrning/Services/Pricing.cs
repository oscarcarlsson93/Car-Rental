using Biluthyrning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Services
{
    public class Pricing
    {
        public static decimal baseDayRental = 100;
        public static decimal kmPrice = 10;

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

            //_context.Update(booking);
            //_context.Update(booking.Car);
            //_context.SaveChanges();

        }


    }
}
