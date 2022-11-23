using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopProject.Models
{
    public class Comments
    {
        [Required]
       
        public int CommentsId { get; set; }

        [Display(Name ="comment")]
        [DataType(DataType.MultilineText)]
        [Range(1,100)]
        [Required (ErrorMessage ="please write a valid comment")]
        public string? Descripition { get; set; }
        [ForeignKey("AnimalId")]
        public int AnimalId { get; set; }

        public virtual Animal Animal { get; set; } = null!;
    }
}
