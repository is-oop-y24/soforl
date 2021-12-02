using System;
using Banks.Classes;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var centralBank = new CentralBank();
            Bank bank = centralBank.RegisterBank("Sberbank", 10000);
            Console.WriteLine("Enter your first name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string lastName = Console.ReadLine();
            Client client = centralBank.AddClient(bank, name, lastName);
            Console.WriteLine("Do you want to add address? Type yes or no");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Enter your address");
                string address = Console.ReadLine();
                centralBank.AddClientAddress(address, client);
            }

            Console.WriteLine("Do you want to add passport? Type yes or no");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Enter your passport");
                string passport = Console.ReadLine();
                centralBank.AddClientPassport(passport, client);
            }

            BankAccount account = null;

            Console.WriteLine("What first account do you want to create? Enter 1 - credit; 2 - debit; 3 - deposit");
            int number = int.Parse(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account = centralBank.AddCreditAccount(client, bank, sum, 10, new DateTime(2021, 12, 30), 730);
            }
            else if (number == 2)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account = centralBank.AddDebitAccount(client, bank, sum, 10, new DateTime(2021, 12, 30));
            }
            else if (number == 3)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account = centralBank.AddDepositAccount(client, bank, sum, 10, new DateTime(2021, 12, 30));
            }
            else
            {
                Console.WriteLine("Enter the right number");
            }

            Console.WriteLine("Money on the accounts before scrolling time:");

            foreach (Bank bank1 in centralBank.GetBanks())
            {
                foreach (BankAccount account1 in bank1.GetBankAccounts())
                {
                    Console.WriteLine(account1.Sum);
                }
            }

            Console.WriteLine("Money on the accounts after scrolling time:");

            centralBank.ScrollingTime(new DateTime(2021, 12, 29));
            foreach (var bank1 in centralBank.GetBanks())
            {
                foreach (var account1 in bank1.GetBankAccounts())
                {
                    Console.WriteLine(account1.Sum);
                }
            }

            BankAccount account2 = null;

            Console.WriteLine("What second account do you want to create? Enter 1 - credit; 2 - debit; 3 - deposit");
            int number2 = int.Parse(Console.ReadLine());
            if (number2 == 1)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account2 = centralBank.AddCreditAccount(client, bank, sum, 10, new DateTime(2021, 12, 30), 730);
            }
            else if (number2 == 2)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account2 = centralBank.AddDebitAccount(client, bank, sum, 10, new DateTime(2021, 12, 30));
            }
            else if (number2 == 3)
            {
                Console.WriteLine("Write sum that will be on your bank account");
                double sum = double.Parse(Console.ReadLine());
                account2 = centralBank.AddDepositAccount(client, bank, sum, 10, new DateTime(2021, 12, 30));
            }
            else
            {
                Console.WriteLine("Enter the right number");
            }

            Console.WriteLine("Write sum that will be transfered to different bank account");
            double sum2 = double.Parse(Console.ReadLine());
            Console.WriteLine(account.TransferPartMoney(sum2, account2));

            Console.WriteLine("Money on the accounts after transfering:");

            foreach (var bank1 in centralBank.GetBanks())
            {
                foreach (var account1 in bank1.GetBankAccounts())
                {
                    Console.WriteLine(account1.Sum);
                }
            }
        }
    }
}
