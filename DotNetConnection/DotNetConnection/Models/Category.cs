using System.ComponentModel.DataAnnotations;

namespace DotNetConnection.Models
{
    public class Category:DateEntity
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
