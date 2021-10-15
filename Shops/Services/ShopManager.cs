using System.Collections.Generic;
using Shops.Classes;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private List<Product> _allProducts = new List<Product>();
        private List<Shop> shops = new List<Shop>();

        public Product RegisterProduct(string name)
        {
            var newProduct = new Product(name);
            newProduct.Amount = int.MaxValue;
            _allProducts.Add(newProduct);
            return newProduct;
        }

        public Product AddShopProduct(Shop newShop, Product product, int amount,  int price)
        {
            bool checkProductStorage = false;
            bool checkProductShop = false;
            foreach (Product products in _allProducts)
            {
                if (products.Name == product.Name)
                {
                    checkProductStorage = true;
                    break;
                }
            }

            if (checkProductStorage == false)
            {
                throw new ShopException("Invalid name of product");
            }

            foreach (Product prod in newShop.Products)
            {
                if (prod.Name == product.Name)
                {
                    checkProductShop = true;
                    break;
                }
            }

            if (checkProductShop == false)
            {
                var newProd = new Product(product.Name);
                newProd.Price = price;
                newProd.Amount += amount;
                newShop.Products.Add(newProd);
                return newProd;
            }

            foreach (Product prod in newShop.Products)
            {
                if (prod.Id == product.Id)
                {
                    prod.Amount += amount;
                    return prod;
                }
            }

            return null;
        }

        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(name, address);
            shops.Add(shop);
            return shop;
        }

        public Shop BuyProduct(Shop shop, Person person, string nameProduct, int amount)
        {
            foreach (Product prod in shop.Products)
            {
                if (nameProduct == prod.Name)
                {
                    if (prod.Amount >= amount)
                    {
                        if (person.Money >= amount * prod.Price)
                        {
                            person.Money -= amount * prod.Price;
                            prod.Amount -= amount;
                            return shop;
                        }
                    }
                }
            }

            throw new ShopException("No product in Shops");
        }

        public Shop DeliverCheapestProduct(Person person, string nameProduct, int amount)
        {
            int newId = MinPriceProduct(nameProduct, amount);
            foreach (Shop newShop in shops)
            {
                if (newShop.Id == newId)
                {
                    foreach (Product prod in newShop.Products)
                    {
                        if ((prod.Name == nameProduct) && (person.Money >= prod.Price * amount))
                        {
                            person.Money -= amount * prod.Price;
                            prod.Amount -= amount;
                            return newShop;
                        }
                    }
                }
            }

            throw new ShopException("The product can't be bought");
        }

        public void ChangePriceProduct(Shop shop, Product product, int newPrice)
        {
            foreach (Product newProd in shop.Products)
            {
                if (product.Id == newProd.Id)
                {
                    newProd.Price = newPrice;
                }
            }
        }

        public int MinPriceProduct(string nameProduct, int amount)
        {
            int minPrice = int.MaxValue;
            int idShop = -1;
            foreach (Shop newShop in shops)
            {
                foreach (Product prod in newShop.Products)
                {
                    if ((nameProduct == prod.Name) && (prod.Amount >= amount) && (prod.Price < minPrice))
                    {
                        minPrice = prod.Price;
                        idShop = newShop.Id;
                        break;
                    }
                }
            }

            if ((minPrice != int.MaxValue) && (idShop != -1))
            {
                return idShop;
            }

            throw new ShopException("No product in Shops");
        }
    }
}