using Biluthyrning.Data;
using Biluthyrning.Repositories;
using Microsoft.AspNetCore.Mvc;
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

    }
}
