using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        //public int BookingNumber { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Active { get; set; } = true;
        public int Distance { get; set; }
        public decimal RentedDays 
        { 
            get
            {
                decimal numberOfRentedDays = (ReturnDate - PickUpDate).Days + 1;
                return numberOfRentedDays;
            }
        }
        public decimal Price { get; set; }



        public Car Car { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
