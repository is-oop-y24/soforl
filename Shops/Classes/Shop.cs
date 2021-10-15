using System.Collections.Generic;

namespace Shops.Classes
{
    public class Shop
    {
        private static int _id;
        public Shop(string name, string address)
        {
            Id = GenerateId();
            Name = name;
            Address = address;
            Products = new List<Product>();
        }

        public int Id { get; }
        public string Name { get; }
        public string Address { get; }
        public List<Product> Products { get; }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}