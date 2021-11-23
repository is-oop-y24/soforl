using System;
using System.Collections.Generic;

namespace Shops.Classes
{
    public class Shop
    {
        private string _shopName;
        private string _shopAddress;
        private Guid _shopId;
        private List<Product> _shopProducts;
        public Shop(string name, string address)
        {
            _shopId = Guid.NewGuid();
            _shopName = name;
            _shopAddress = address;
            _shopProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _shopProducts.Add(product);
        }

        public string GetShopName()
        {
            return _shopName;
        }

        public string GetAddress()
        {
            return _shopAddress;
        }

        public Guid GetShopId()
        {
            return _shopId;
        }

        public List<Product> GetShopProducts()
        {
            return _shopProducts;
        }
    }
}