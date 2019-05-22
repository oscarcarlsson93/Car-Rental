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
        private readonly IEventsRepository _eventsRepository;

        public CarController(ApplicationDbContext context, ICarRepository carRepository, IEventsRepository eventsRepository)
        {
            _context = context;
            _carRepository = carRepository;
            _eventsRepository = eventsRepository;
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


        public IActionResult Delete(int? id)
        {
            var car = _carRepository.GetCarById(id);

            return View(car);
        }

        [HttpPost, ActionName("EditCar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(CarVm carVm)
        {
            if (carVm.Event.EventType == EventType.Cleaning)
            {
                carVm.Car.Cleaning = false;
            }
            if (carVm.Event.EventType == EventType.Service)
            {
                carVm.Car.Service = false;
            }
                  //var car = _carRepository.GetCarById(id);
            _carRepository.UpdateCar(carVm.Car);

            _eventsRepository.AddEvent(carVm);


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var car = _carRepository.GetCarById(id);

            var carVm = new CarVm();


            string[] arr = Enum.GetNames(typeof(EventType));
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in arr)
            {
                var y = new SelectListItem() { Text = item, Value = item };
                list.Add(y);
            }


            carVm.AllEventTypes = list;
            carVm.Car = car;



            return View(carVm);
        }

        public IActionResult CarEvents(int? id)
        {

          var carEvents =   _eventsRepository.GetAllCarEvents(id);
            return View(carEvents);
        }
        
        public IActionResult EventIndex()
        {
            var allEvents = _eventsRepository.GetAllEvents();

            return View(allEvents);
        }
        

    }
}
