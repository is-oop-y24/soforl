using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Client
    {
        public Client(string firstName, string lastName, string address, string passport)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Passport = passport;
            ClientAccounts = new Dictionary<Bank, BankAccount>();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; private set; }
        public string Passport { get; private set; }
        public Dictionary<Bank, BankAccount> ClientAccounts { get; }

        public void AddAddress(string address)
        {
            Address = address;
        }

        public void AddPassport(string passport)
        {
            Passport = passport;
        }

        public ClientBuilder ToBuild(ClientBuilder client)
        {
            client.BuildFirstName(FirstName)
                .BuildLastName(LastName)
                .BuildAddress(Address)
                .BuildPassport(Passport);
            return client;
        }

        public bool CheckRegistration()
        {
            if (Address != null && Passport != null)
            {
                return true;
            }

            return false;
        }

        public Dictionary<Bank, BankAccount> AddBankAccount(Bank bank, BankAccount bankAccount)
        {
            ClientAccounts.Add(bank, bankAccount);
            return ClientAccounts;
        }

        public class ClientBuilder
        {
            private string _clientFirstName;
            private string _clientLastName;
            private string _clientAddress = null;
            private string _clientPassport = null;

            public ClientBuilder BuildFirstName(string firstName)
            {
                _clientFirstName = firstName;
                return this;
            }

            public ClientBuilder BuildLastName(string lastName)
            {
                _clientLastName = lastName;
                return this;
            }

            public ClientBuilder BuildAddress(string address)
            {
                if (address != string.Empty)
                {
                    _clientAddress = address;
                }

                return this;
            }

            public ClientBuilder BuildPassport(string passport)
            {
                if (passport != string.Empty)
                {
                    _clientPassport = passport;
                }

                return this;
            }

            public Client Build()
            {
                var client = new Client(_clientFirstName, _clientLastName, _clientAddress, _clientPassport);

                return client;
            }
        }
    }
}