using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biluthyrning.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddCar(Car car)
        {
            car.RegistrationNumber = car.RegistrationNumber.ToUpper();

            _context.Add(car);
            _context.SaveChanges();
        }

        public List<SelectListItem> AllCarList(IEnumerable<Car> allCars)
        {
            var listOfCars = new List<SelectListItem>();

            foreach (var car in allCars)
            {
                var x = new SelectListItem() { Text = car.RegistrationNumber, Value = car.Id.ToString() };
                listOfCars.Add(x);
            }
            return listOfCars;
        }

        public void DeleteCar(Car car)
        {
                _context.Car.Remove(car);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetAllCarBookings(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Car.ToList();
        }

        public Car GetCarById(int? id)
        {
            return _context.Car.FirstOrDefault(x => x.Id == id);

        }

        public void UpdateCar(Car car)
        {
            //car.Cleaning = true;

            //car.Counter ++;

            //if (car.Counter % 3 == 0)
            //{
            //    car.Service = true;
            //}

            //if (car.DrivenKm > 2000)
            //{
            //    car.Dispose = true;
            //}
            _context.Update(car);
           _context.SaveChanges();
        }

        public void UpdateCarStatus(int? id)
        {
            var car = _context.Car.FirstOrDefault(x => x.Id == id);
            car.Booked = true;

            _context.Update(car);
            _context.SaveChanges();

        }
    }
}
