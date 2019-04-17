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
        public DateTime PickUpDate { get; set; }

        [Display(Name = "Återlämningsdatum")]
        //[Required(ErrorMessage = "Ange datumet för återlämning")]
        [ValidationReturnDate]
        public DateTime? ReturnDate { get; set; } 


        [Display(Name = "Körda kilometer")]
        [Required(ErrorMessage = "Ange antalet körda kilometer")]
        public int Distance { get; set; }


        public decimal RentedDays
        {
            get
            {
                if (ReturnDate != null)
                {
                    decimal numberOfRentedDays = (ReturnDate - PickUpDate).Value.Days + 1;
                return numberOfRentedDays;
                }
                else
                {
                    return 1;
                }
            }
        }
        public decimal Price { get; set; }

        public bool Active { get; set; } = true;

        public Car Car { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public class ValidationReturnDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var booking = (Booking) validationContext.ObjectInstance;


                if (booking.PickUpDate < booking.ReturnDate || booking.Distance == 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Inlämningsdatumet måste vara senare än upphämtningsdatumet");
                }
                //return base.IsValid(value, validationContext);
            }
        }



        //public class ValidationRentedDays : ValidationAttribute
        //{
        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        var rentedDays = value.ToString();
        //        var hyrdaDagar = int.Parse(rentedDays);


        //        if (hyrdaDagar > 0)
        //        {
        //            return ValidationResult.Success;
        //        }
        //        else
        //        {
        //            return new ValidationResult("Inlämningsdatumet måste vara efter uthyrningsdatumet");
        //        }
        //    }
        //}
    }
}
