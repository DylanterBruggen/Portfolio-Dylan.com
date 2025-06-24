using System.ComponentModel.DataAnnotations;

namespace Portfolio_Dylan_Web.Models
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Voer een geldig emailadres in.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Bericht is verplicht.")]
        public string Message { get; set; } = null!;
    }
}
