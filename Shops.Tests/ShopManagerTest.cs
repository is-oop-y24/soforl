using NUnit.Framework;
using Shops.Classes;
using Shops.Services;
using Shops.Tools;

namespace Shops.Tests
{
    public class ShopManagerTest
    {
        private IShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void AddProductToShop_ShopContainsProductAndProductHasShop_ThrowException()
        {
            Shop shop = _shopManager.AddShop("Metro", "Lenin street, 13");
            Product product1 = _shopManager.RegisterProduct("banana", 40, 10);
            var prodBuild = new ProductBuilder();
            Product product2 = prodBuild.BuildName("candy")
                .BuildAmount(23)
                .BuildPrice(5)
                .Build();
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.AddShopProduct(shop, product2, 6, 14);
            });
        }

        [Test]
        public void ChangeProductPriceToAnother_PriceChanged()
        {
            Shop shop = _shopManager.AddShop("Lenta", "Kronverskiy pr., 24");
            Product product = _shopManager.RegisterProduct("milk", 37, 20);
            Product prod = _shopManager.AddShopProduct(shop, product, 10, 32);
            _shopManager.ChangePriceProduct(shop, prod, 40);
            Assert.AreEqual(40, prod.GetPrice());
        }

        [Test]
        public void FindCheapestProduct_ShopContainsProduct_ThrowException()
        {
            Shop shop1 = _shopManager.AddShop("Diksi", "Kirov street, 18");
            Shop shop2 = _shopManager.AddShop("Okey", "Pavlov street, 18");
            Shop shop3 = _shopManager.AddShop("Lenta", "Kirov street, 78");
            Product product = _shopManager.RegisterProduct("avocado", 70, 30);
            Product prod1 = _shopManager.AddShopProduct(shop1, product, 2, 59);
            Product prod2 = _shopManager.AddShopProduct(shop2, product, 2, 37);
            Product prod3 = _shopManager.AddShopProduct(shop3, product, 2, 76);
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.MinPriceProduct("avocado", 3);
                _shopManager.MinPriceProduct("milk", 1);
            });

        }
        
        [Test]
        public void BuyProduct_PersonHasMoney_EnoughAmountProduct_ThrowException()
        {
            var person1 = new Person(10000);
            var person2 = new Person(10);
            Shop shop = _shopManager.AddShop("Diksi", "Kirov street, 18");
            Product product1 = _shopManager.RegisterProduct("carrot", 73, 3);
            Product product2 = _shopManager.RegisterProduct("milk", 9, 4);
            Product prod1 = _shopManager.AddShopProduct(shop, product1, 5, 59);
            Product prod2 = _shopManager.AddShopProduct(shop, product2, 5, 37);
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.BuyProduct(shop, person1, "carrot", 7);
                _shopManager.BuyProduct(shop, person2, "carrot", 2);
            });
        }

    


    }
}