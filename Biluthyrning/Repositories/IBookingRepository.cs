using Biluthyrning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Repositories
{
    public interface IBookingRepository
    {
        IOrderedEnumerable<Booking> GetAllBookings();

        Booking GetBookingById(Guid? id);

        void CreateBooking(BookingVm vm);

        void Payment(Booking booking);

    }
}
