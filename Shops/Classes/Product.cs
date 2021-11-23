using System;

namespace Shops.Classes
{
    public class Product
    {
        private string _productName;
        private int _price;
        private int _amount;
        public Product(ProductBuilder product)
        {
            _productName = product.GetName();
            _price = product.GetPrice();
            _amount = product.GetAmount();
        }

        public ProductBuilder ToBuild()
        {
            ProductBuilder productBuilder = new ();
            productBuilder.BuildName(_productName);
            productBuilder.BuildAmount(_amount);
            productBuilder.BuildPrice(_price);
            return productBuilder;
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

        public int Price(int price)
        {
            _price = price;
            return _price;
        }

        public int Amount(int amount)
        {
            _amount = amount;
            return _amount;
        }
    }
}