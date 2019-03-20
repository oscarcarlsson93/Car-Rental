using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class BookingVm
    {
        public Booking Booking { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SelectListItem> AllCarTypes { get; set; }



    }
}
