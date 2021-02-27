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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required]
        public string Game { get; set; }
    }
}
