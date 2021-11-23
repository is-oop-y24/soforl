using System;
using System.Collections.Generic;

namespace Shops.Classes
{
    public class ProductBuilder
    {
        private string _productName;
        private int _price;
        private int _amount;

        public ProductBuilder BuildName(string name)
        {
            _productName = name.ToLower();
            return this;
        }

        public ProductBuilder BuildPrice(int price)
        {
            _price = price;
            return this;
        }

        public ProductBuilder BuildAmount(int amount)
        {
            _amount = amount;
            return this;
        }

        public Product Build()
        {
            Product newProduct = new (this);
            return newProduct;
        }

        public string GetName()
        {
            return _productName;
        }

        public int GetAmount()
        {
            return _amount;
        }

        public int GetPrice()
        {
            return _price;
        }
    }
}