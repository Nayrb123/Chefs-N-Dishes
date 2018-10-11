using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace chefs_dishes.Models
{
    public class Chef
    {
        [Key]
        public int Chefid { get; set; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        public DateTime Date_of_Birth { get; set; }
        public int age
        {
            get { return DateTime.Now.Year - Date_of_Birth.Year;}
        }
        
        public List<Dish> Dishes { get; set; }
    }
}