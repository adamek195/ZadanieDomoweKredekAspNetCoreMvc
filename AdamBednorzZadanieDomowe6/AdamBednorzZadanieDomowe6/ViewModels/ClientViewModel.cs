using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Game { get; set; }
    }
}
