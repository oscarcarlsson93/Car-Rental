using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Car
    {
        

        public int Id { get; set; }
        public CarType CarType { get; set; }

        [Display(Name = "Nummerskylt")]
        [Required(ErrorMessage = "Du måste ange ett registreringsnummer på bilen")]
        [RegularExpression("[A-ZÅÄÖa-zåäö]{3}[0-9]{3}", ErrorMessage = "Ange formatet ABC123")]
        public string RegistrationNumber { get; set; } 
        public int DrivenKm { get; set; }

        public List<Booking> Bookings { get; set; }

        public bool Booked { get; set; } = false;

    }
        public enum CarType
        {
            Small,
            Van,
            Minibus
        }
}
