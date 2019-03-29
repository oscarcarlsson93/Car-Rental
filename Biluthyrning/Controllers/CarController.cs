using Biluthyrning.Data;
using Biluthyrning.Models;
using Biluthyrning.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarRepository _carRepository;

        public CarController(ApplicationDbContext context, ICarRepository carRepository)
        {
            _context = context;
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            var xxx = _carRepository.GetAllCars();
            return View(xxx);  
        }

        public IActionResult Create()
        {
            CarVm carVm = new CarVm();


            string[] arr = Enum.GetNames(typeof(CarType));
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in arr)
            {
                var y = new SelectListItem() { Text = item, Value = item };
                list.Add(y);
            }
            carVm.AllCarTypes = list;
            return View(carVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.AddCar(car);
                return RedirectToAction(nameof(Index));
            }
            return View("Index", car);
        }

    }
}
