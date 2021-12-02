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

        public Client AddClient(Bank bank, string firstName, string lastName, string passport = "", string address = "")
        {
            if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName))
            {
                Client client = new Client.ClientBuilder()
                    .BuildFirstName(firstName)
                    .BuildLastName(lastName)
                    .BuildPassport(passport)
                    .BuildAddress(address)
                    .Build();
                bank.GetClients().Add(client);
                return client;
            }

            throw new Exception("Invalid client");
        }

        public Client AddClientAddress(string address, Client client)
        {
            client.AddAddress(address);
            return client;
        }

        public Client AddClientPassport(string passport, Client client)
        {
            client.AddPassport(passport);
            return client;
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