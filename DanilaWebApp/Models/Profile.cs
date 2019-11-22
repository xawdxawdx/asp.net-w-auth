using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DanilaWebApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        
        [Remote(action: "IsMe", controller: "Profile", ErrorMessage = "Can\'t be another me!")]
        public string Name { get; set; }
        [Range(18, 65)]
        public int Age { get; set; }
        
        public string UserId { get; set; }
        
        public virtual User User { get; set; }
        
        public virtual Order Order { get; set; }
    }
}