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

    }
}
