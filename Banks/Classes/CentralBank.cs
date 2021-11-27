using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _banks = new List<Bank>();

        public Bank RegisterBank(string name, double limit)
        {
            var bank = new Bank(name, limit);
            _banks.Add(bank);
            return bank;
        }

        public Client AddClient(string firstName, string lastName)
        {
            Client client = new Client.ClientBuilder()
                .BuildFirstName(firstName)
                .BuildLastName(lastName)
                .Build();
            return client;
        }

        public Client AddClientAddress(string address, Client client)
        {
            var clientBuilder = new Client.ClientBuilder();
            Client newClient = Client
                .ToBuild(clientBuilder)
                .BuildAddress(address)
                .BuildPassport(client.GetPassport())
                .BuildFirstName(client.GetFirstName())
                .BuildLastName(client.GetLastName())
                .Build();
            return newClient;
        }

        public Client AddClientPassport(string passport, Client client)
        {
            var clientBuilder = new Client.ClientBuilder();
            Client newClient = Client
                .ToBuild(clientBuilder)
                .BuildPassport(passport)
                .BuildAddress(client.GetAddress())
                .BuildFirstName(client.GetFirstName())
                .BuildLastName(client.GetLastName())
                .Build();
            return newClient;
        }

        public BankAccount AddCreditAccount(Client client, Bank bank, double sum, double percentage, DateTime dateFinishing, int daysCommission)
        {
            BankAccount bankAccount = new CreditAccount(percentage, sum, client, bank, dateFinishing, daysCommission);
            bank.GetBankAccounts().Add(bankAccount);
            return bankAccount;
        }

        public BankAccount AddDepositAccount(Client client, Bank bank, double sum, double percentage, DateTime dateFinishing)
        {
            BankAccount bankAccount = new DepositAccount(sum, client, bank, dateFinishing);
            bank.GetBankAccounts().Add(bankAccount);
            return bankAccount;
        }

        public BankAccount AddDebitAccount(Client client, Bank bank, double sum, double percentage, DateTime dateFinishing)
        {
            BankAccount bankAccount = new DebitAccount(percentage, sum, client, bank, dateFinishing);
            bank.GetBankAccounts().Add(bankAccount);
            return bankAccount;
        }

        public void ScrollingTime(DateTime date)
        {
            foreach (Bank bank in _banks)
            {
                foreach (BankAccount bankAccount in bank.GetBankAccounts())
                {
                    bankAccount.CalculatePercentage(date);
                }
            }
        }

        public List<Bank> GetBanks()
        {
            return _banks;
        }
    }
}