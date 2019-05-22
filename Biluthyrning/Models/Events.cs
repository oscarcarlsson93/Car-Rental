using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Events
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public EventType EventType { get; set; }


        public int MyProperty { get; set; }

        public Car Car { get; set; }
        public int? CarId { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }

    }
        public enum EventType
        {
            Service,
            Cleaning,
            Disposed
        }
}
