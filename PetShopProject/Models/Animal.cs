﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopProject.Models
{
    public class Animal
    {
        [Display(Name = "ID:")]
        [Required(ErrorMessage = "Please enter ID.")]

        public int AnimalId { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter Name.")]
        public string? Name { get; set; }

        [Display(Name = "Age:")]
        [Required(ErrorMessage = "Please enter valid age.")]
        public int Age { get; set; }

        [Display(Name = "Descripition:")]
        [Required(ErrorMessage = "Please enter valid Descripition.")]
        public string? Descripition { get; set; }

        [Display(Name = "Picture Path:")]
        [Required(ErrorMessage = "Please enter valid PicturePath.")]
        public string? PicturePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<Comments>? Comments { get; set; }
        [NotMapped]
        public  IFormFile File { get; set; }
        
    }
}