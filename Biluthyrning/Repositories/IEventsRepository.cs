using Biluthyrning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Repositories
{
   public interface IEventsRepository
    {

        IOrderedEnumerable<Events> GetAllEvents();

        //Booking GetBookingById(Guid? id);

        void AddEvent(CarVm carVm);


        IEnumerable<Events> GetAllCarEvents(int? id);



    }
}
