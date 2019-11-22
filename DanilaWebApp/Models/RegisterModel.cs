using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Registration Date can't be null'")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
