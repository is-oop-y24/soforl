using System;
using Shops.Classes;

namespace Shops.Services
{
    public interface IShopManager
    {
        Product RegisterProduct(string name, int amount, int price);
        Product AddShopProduct(Shop newShop, Product product, int amount, int price);
        Shop AddShop(string name, string address);
        Shop BuyProduct(Shop shop, Person person, string nameProduct, int amount);
        Shop DeliverCheapestProduct(Person person, string nameProduct, int amount);
        void ChangePriceProduct(Shop shop, Product product, int newPrice);
        Guid MinPriceProduct(string nameProduct, int amount);
    }
}