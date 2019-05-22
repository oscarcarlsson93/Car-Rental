using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class CarVm
    {
        public Car Car { get; set; }
        public IEnumerable<SelectListItem> AllCarTypes { get; set; }

        public IEnumerable<SelectListItem> AllEventTypes { get; set; }
        public Events Event { get; set; }

    }
}
