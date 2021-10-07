namespace Shops.Classes
{
    public class Product
    {
        private static int _id;
        public Product(string name)
        {
            Name = name.ToLower();
            Id = GenerateId();
        }

        public int Id { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Name { get; }

        private int GenerateId()
        {
            ++_id;
            return _id;
        }
    }
}