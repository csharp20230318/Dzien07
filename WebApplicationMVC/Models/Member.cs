using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Member
    {
        [Required(ErrorMessage ="Podaj nazwę")]
        [MinLength(2, ErrorMessage ="Za krótki tekst")]
        [MaxLength(10, ErrorMessage ="Za długi")]
        //[StringLength(30)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Url]
        public string Url { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage ="Podaj poprawny kod")]
        public string ZipCode { get; set; } = "";

        //[Range(10, 20, ErrorMessage ="Wartośc spoza zakresu")]
        [AgeOver(18)]
        public int Age { get; set; }

    }
}
