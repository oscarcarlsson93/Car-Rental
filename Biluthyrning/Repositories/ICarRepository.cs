using Biluthyrning.Models;
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

        List<SelectListItem> AllCarList(IEnumerable<Car> allCars);
    }
}
