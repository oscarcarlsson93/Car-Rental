using Biluthyrning.Data;
using Biluthyrning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _context;

    

        public EventsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public void AddEvent(Events events)
        //{
        //    _context.Add(events);
        //    _context.SaveChanges();
        //}

        public void AddEvent(CarVm carVm)
        {
            var events = new Events();

            events.Time = DateTime.Now;
            events.EventType = carVm.Event.EventType;
            events.CarId = carVm.Car.Id;

            _context.Add(events);
            _context.SaveChanges();
        }

        public IEnumerable<Events> GetAllCarEvents(int? id)
        {

            return _context.Events.Where(x => x.CarId == id).ToList();

        }

        public IOrderedEnumerable<Events> GetAllEvents()
        {

            return _context.Events.Include(x => x.Car).Include(z => z.Customer).ToList().OrderByDescending(k => k.Time);
            //return _context.Booking.Include(x => x.Car).Include(z => z.Customer).ToList().OrderBy(k => k.Active == false);
        }
    }
}
