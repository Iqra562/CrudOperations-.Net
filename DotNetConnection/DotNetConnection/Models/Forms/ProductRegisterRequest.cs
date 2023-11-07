using System.ComponentModel.DataAnnotations;

namespace DotNetConnection.Models.Forms
{
    public class ProductRegisterRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
