using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class AgeOver :  ValidationAttribute
    {
        public int Age { get; }
        public AgeOver(int age)
        {
            Age = age;
        }

        public string GetErrorMessage() => $"Wiek musi być powyżej {Age}";

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var member = (Member)validationContext.ObjectInstance;
            if (member.Age<Age)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}