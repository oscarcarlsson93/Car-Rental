﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime PickUpDate { get; set; }

        [Display(Name = "Återlämningsdatum")]
        [Required(ErrorMessage = "Ange datumet för återlämning")]
        public DateTime ReturnDate { get; set; }

        public bool Active { get; set; } = true;

        [Display(Name = "Körda kilometer")]
        [Required(ErrorMessage = "Ange antalet körda kilometer")]
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