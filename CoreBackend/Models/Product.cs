namespace CRUDBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Product()
        {
            Id = 0;
            Name = string.Empty;
            Quantity = 0;
            Description = string.Empty;
        }

        public Product(int id, string name, string description, int quantity)
        {
            Id= id;
            Name = name;
            Description = description;
            Quantity = quantity;
        }
    }
}