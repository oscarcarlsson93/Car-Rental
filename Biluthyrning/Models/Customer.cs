using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biluthyrning.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Personnummer")]
        [RegularExpression("^[0-9]{2}([0][1-9]|[1][1-2])([0][1-9]|[1][0-9]|[2][0-9]|[3][0-1])-?[0-9]{4}$", ErrorMessage = "Ange formatet YYMMDD-XXXX tack")]
        public string PersonalNumber { get; set; }

        public List<Booking> Bookings { get; set; }

        public MemberLevel MemberLevel { get; set; }

        public int NumberOfRents { get; set; }

        public int RentedKm { get; set; }

    }
        public enum MemberLevel
        {
            Bronze,
            Silver,
            Gold
        }
}
