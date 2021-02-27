using System.ComponentModel.DataAnnotations;

namespace AdamBednorzZadanieDomowe6.ViewModels
{
    public class ContactFormViewModel
    {
        //atrybuty modelu
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Naziwsko")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Opinia")]
        public string Message { get; set; }
    }
}
