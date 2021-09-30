using System.Collections.Generic;

namespace Shops.Classes
{
    public class Shop
    {
        public Shop(string name, string address)
        {
            Id = new GenerateId().Id;
            Name = name;
            Address = address;
            Products = new List<Product>();
        }

        public int Id { get; }
        public string Name { get; }
        public string Address { get; }
        public List<Product> Products { get; }
    }
}