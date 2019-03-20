using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Customer
    {
      

        public int Id { get; set; }
        public string PersonalNumber { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
