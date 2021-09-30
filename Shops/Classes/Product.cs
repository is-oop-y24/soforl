namespace Shops.Classes
{
    public class Product
    {
        public Product(string name)
        {
            Name = name.ToLower();
            Id = new GenerateId().Id;
        }

        public int Id { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Name { get; }
    }
}