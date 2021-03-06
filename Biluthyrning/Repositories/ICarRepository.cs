﻿using Biluthyrning.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Repositories
{
    public interface ICarRepository
    {

        IEnumerable<Car> GetAllCars();

        Car GetCarById(int? id);

        IEnumerable<Booking> GetAllCarBookings(int? id);

        void AddCar(Car car);
        void DeleteCar(Car car);
        void UpdateCar(Car car);

        void UpdateCarStatus(int? id);

        List<SelectListItem> AllCarList(IEnumerable<Car> allCars);
    }
}
