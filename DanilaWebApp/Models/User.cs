using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DanilaWebApp.Models
{
    public class User : IdentityUser,IValidatableObject
    {
        
        //public int Id { get; set; }
        
        [Required(ErrorMessage = "Login can\'t be null")]
        //public string Login { get; set; }
        
        [PasswordError(ErrorMessage = "Password is not valid")]
        public string Password { get; set; }
       // public int? RoleId { get; set; }
       // public Role Role { get; set; }

        [Required(ErrorMessage = "Registration Date can't be null'")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public virtual Profile Profile { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName == "Danila")
            {
                yield return new ValidationResult(
                    $"Too many Danila for one program!",
                    new[] { "Login" });
            }
        }
    }
}