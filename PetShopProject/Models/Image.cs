using System.ComponentModel;
using System.Web;

namespace PetShopProject.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string? Title { get; set; }
        [DisplayName("uplode file")]
        public string? ImagePath { get; set; }
        //public h HttpClient { get; set; }
    }
}
