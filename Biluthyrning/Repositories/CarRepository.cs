﻿using System;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
