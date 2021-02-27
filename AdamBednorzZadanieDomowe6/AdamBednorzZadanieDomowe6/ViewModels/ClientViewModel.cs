using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdamBednorzZadanieDomowe6.ViewModels
{
    /// <summary>
    /// klasa opisujaca model klienta, ktory chce wypozyczyc gre
    /// </summary>
    public class ClientViewModel
    {
        //atrybuty modelu
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Numer Telefonu")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Gra")]
        public string Game { get; set; }
    }
}
