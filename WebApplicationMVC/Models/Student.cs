using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Wprowadź coś!")]
        public string Name { get; set; } = default!;
        
        [EmailAddress]
        public string Email { get; set; } = default!;
        public string Country { get; set; } = default!;

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value="PL", Text="Polska"},
            new SelectListItem { Value="DE", Text="Niemcy"},
            new SelectListItem { Value="UK", Text="Wlk Brytania"},
            new SelectListItem { Value="US", Text="USA"},
        };
    }
}
