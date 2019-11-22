using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DanilaWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public virtual Address Address { get; set; }
        
        public int AddressId { get; set; }
        
        public virtual Profile Profile { get; set; }
        
        public int ProfileId { get; set; }
        [Phone(ErrorMessage = "Wrong Phone")]
        [Required(ErrorMessage = "Cant be null")]
        public string ContactPhone { get; set; }
        
        public virtual ICollection<Phone> Phones { get; set; }
    }
}