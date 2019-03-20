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
        public string RegistrationNumber { get; set; }
        public int DrivenKm { get; set; }

        public List<Booking> Bookings { get; set; }

    }
        public enum CarType
        {
            Small,
            Van,
            Minibus
        }
}
