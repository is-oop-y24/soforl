using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Classes;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private List<Product> _allProducts = new List<Product>();
        private List<Shop> _shops = new List<Shop>();

        public Product RegisterProduct(string name, int amount, int price)
        {
            var prodBuild = new ProductBuilder();
            Product newProduct = prodBuild.BuildName(name).BuildAmount(amount).BuildPrice(price).Build();
            _allProducts.Add(newProduct);
            return newProduct;
        }

        public Product AddShopProduct(Shop newShop, Product product, int amount,  int price)
        {
            bool checkProductStorage = false;
            bool checkProductShop = false;
            foreach (Product products in _allProducts)
            {
                if (products.GetName() == product.GetName() && amount <= products.GetAmount())
                {
                    checkProductStorage = true;
                    break;
                }
            }

            if (checkProductStorage == false)
            {
                throw new ShopException("Invalid name of product");
            }

            foreach (Product prod in newShop.GetShopProducts())
            {
                if (prod.GetName() == product.GetName())
                {
                    checkProductShop = true;
                    break;
                }
            }

            if (checkProductShop == false)
            {
                var prodBuild = new ProductBuilder();
                Product prod = prodBuild
                    .BuildName(product.GetName())
                    .BuildAmount(amount)
                    .BuildPrice(price)
                    .Build();
                newShop.AddProduct(prod);
                return prod;
            }

            foreach (Product prod in newShop.GetShopProducts())
            {
                if (prod.GetName() == product.GetName())
                {
                    prod.Amount(amount + prod.GetAmount());
                    return prod;
                }
            }

            return null;
        }

        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(name, address);
            _shops.Add(shop);
            return shop;
        }

        public Shop BuyProduct(Shop shop, Person person, string nameProduct, int amount)
        {
            foreach (Product prod in shop.GetShopProducts())
            {
                if (nameProduct == prod.GetName())
                {
                    if (prod.GetAmount() >= amount)
                    {
                        if (person.Money >= amount * prod.GetPrice())
                        {
                            person.Money -= amount * prod.GetPrice();
                            prod.Amount(prod.GetAmount() - amount);
                            return shop;
                        }
                    }
                }
            }

            throw new ShopException("No product in Shops");
        }

        public Shop DeliverCheapestProduct(Person person, string nameProduct, int amount)
        {
            Guid newId = MinPriceProduct(nameProduct, amount);
            foreach (Shop newShop in _shops)
            {
                if (newShop.GetShopId() == newId)
                {
                    foreach (Product prod in newShop.GetShopProducts())
                    {
                        if ((prod.GetName() == nameProduct) && (person.Money >= prod.GetPrice() * amount))
                        {
                            person.Money -= amount * prod.GetPrice();
                            prod.Amount(prod.GetAmount() - amount);
                            return newShop;
                        }
                    }
                }
            }

            throw new ShopException("The product can't be bought");
        }

        public void ChangePriceProduct(Shop shop, Product product, int newPrice)
        {
            foreach (Product newProd in shop.GetShopProducts())
            {
                if (product.GetName() == newProd.GetName())
                {
                    newProd.Price(newPrice);
                }
            }
        }

        public Guid MinPriceProduct(string nameProduct, int amount)
        {
            int minPrice = int.MaxValue;
            Guid idShop = default;
            foreach (Shop newShop in _shops)
            {
                foreach (Product prod in newShop.GetShopProducts())
                {
                    if ((nameProduct == prod.GetName()) && (prod.GetAmount() >= amount) && (prod.GetPrice() < minPrice))
                    {
                        minPrice = prod.GetPrice();
                        idShop = newShop.GetShopId();
                        break;
                    }
                }
            }

            if (minPrice != int.MaxValue)
            {
                return idShop;
            }

            throw new ShopException("No product in Shops");
        }
    }
}