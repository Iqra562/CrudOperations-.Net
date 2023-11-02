namespace DotNetConnection.Models
{
    public class Product: DateEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
