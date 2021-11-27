using System;
using Banks.Classes;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            CentralBank centralBank = new CentralBank();
            Bank bank = centralBank.RegisterBank("Sberbank", 10000);
            Console.WriteLine("Enter your first name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string lastName = Console.ReadLine();
            Client client = centralBank.AddClient(name, lastName);
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

            Console.WriteLine("Write sum that will be on your bank account");

            double sum = double.Parse(Console.ReadLine());
            BankAccount account = centralBank.AddDebitAccount(client, bank, sum, 10, new DateTime(2021, 12, 30));
            foreach (var bank1 in centralBank.GetBanks())
            {
                foreach (var account1 in bank1.GetBankAccounts())
                {
                    Console.WriteLine(account1.GetSum());
                }
            }

            centralBank.ScrollingTime(new DateTime(2021, 12, 29));
            foreach (var bank1 in centralBank.GetBanks())
            {
                foreach (var account1 in bank1.GetBankAccounts())
                {
                    Console.WriteLine(account1.GetSum());
                }
            }

            Console.WriteLine("Write sum that will be on your bank account");

            double newSum = double.Parse(Console.ReadLine());

            BankAccount account2 = centralBank.AddDebitAccount(client, bank, newSum, 10, new DateTime(2021, 12, 31));
            Console.WriteLine("Write sum that will be transfered to different bank account");
            double sum2 = double.Parse(Console.ReadLine());
            Console.WriteLine(account.TransferPartMoney(sum2, account2));
        }
    }
}
