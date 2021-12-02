using System;
using System.Linq;
using Banks.Classes;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BankTests
    {
        private CentralBank _centralBank;

        [SetUp]
        public void SetUp()
        {
            _centralBank = new CentralBank();
        }

        [Test]
        public void CheckTransferMoneyTwoDebitAccounts_ThrowException()
        {
            Bank bank = _centralBank.RegisterBank("Sberbank", 1000);
            Client client1 = _centralBank.AddClient(bank,"Fedor", "Petrov");
            Client client2 = _centralBank.AddClient(bank,"Petr", "Petrov");
            BankAccount account1 = _centralBank.AddDebitAccount(client1, bank, 19000, 10, new DateTime(2021, 12, 30));
            BankAccount account2 = _centralBank.AddDebitAccount(client2, bank, 14000, 10, new DateTime(2021, 12, 30));
            Assert.Catch<Exception>(() =>
            {
                account1.TransferPartMoney(2000, account2);
            });
        }
        
        [Test]
        public void CheckTransferMoneyDebitCreditAccounts_ThrowException()
        {
            Bank bank = _centralBank.RegisterBank("Sberbank", 100000);
            Client client1 = _centralBank.AddClient(bank,"Fedor", "Petrov");
            Client client2 = _centralBank.AddClient(bank,"Petr", "Petrov");
            BankAccount account1 = _centralBank.AddDebitAccount(client1, bank, 19000, 10, new DateTime(2021, 12, 30));
            BankAccount account2 = _centralBank.AddCreditAccount(client2, bank, 10000, 10, new DateTime(2021, 12, 30), 10);
            Assert.Catch<Exception>(() =>
            {
                account2.TransferPartMoney(12000, account1);
            });
        }
        
        [Test]
        public void CheckTransferMoneyTwoDebitAccounts()
        {
            Bank bank = _centralBank.RegisterBank("Sberbank", 1000);
            Client client1 = _centralBank.AddClient(bank,"Fedor", "Petrov");
            Client client2 = _centralBank.AddClient(bank,"Petr", "Petrov");
            BankAccount account1 = _centralBank.AddDebitAccount(client1, bank, 19000, 10, new DateTime(2021, 12, 30));
            BankAccount account2 = _centralBank.AddDebitAccount(client2, bank, 14000, 10, new DateTime(2021, 12, 30));
            _centralBank.AddClientAddress("Lomonosova", client2);
            _centralBank.AddClientPassport("meow", client2);
            account2.TransferPartMoney(2000, account1);
            Assert.AreEqual(21000, account1.Sum);
        }
        
        [Test]
        public void CancelTransaction_()
        {
            Bank bank = _centralBank.RegisterBank("Sberbank", 10000000);
            Client client1 = _centralBank.AddClient(bank,"Fedor", "Petrov");
            Client client2 = _centralBank.AddClient(bank,"Petr", "Petrov");
            BankAccount account1 = _centralBank.AddDebitAccount(client1, bank, 19000, 10, new DateTime(2021, 12, 30));
            BankAccount account2 = _centralBank.AddDebitAccount(client2, bank, 14000, 10, new DateTime(2021, 12, 30));
            _centralBank.AddClientAddress("Lomonosova", client2);
            _centralBank.AddClientPassport("meow", client2);
            account1.TransferPartMoney(2000, account2);
            bank.CancelTransaction(account2, account1, account2.Transactions.Last());
            Assert.AreEqual(14000, account2.Sum);
        }
        
    }
}