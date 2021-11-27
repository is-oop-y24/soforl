using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Client
    {
        private static string _clientFirstName;
        private static string _clientLastName;
        private static string _clientAddress;
        private static string _clientPassport;
        private static bool _clientFinishedRegistration;

        public Client(string firstName, string lastName, string address, string passport, bool checkRegistration)
        {
            _clientFirstName = firstName;
            _clientLastName = lastName;
            _clientAddress = address;
            _clientPassport = passport;
            _clientFinishedRegistration = checkRegistration;
            ClientAccounts = new Dictionary<Bank, BankAccount>();
        }

        public Dictionary<Bank, BankAccount> ClientAccounts { get; }

        public static ClientBuilder ToBuild(ClientBuilder client)
        {
            client.BuildFirstName(_clientFirstName)
                .BuildLastName(_clientLastName)
                .BuildAddress(_clientAddress)
                .BuildPassport(_clientPassport);
            return client;
        }

        public string GetFirstName()
        {
            return _clientFirstName;
        }

        public string GetLastName()
        {
            return _clientLastName;
        }

        public string GetAddress()
        {
            return _clientAddress;
        }

        public string GetPassport()
        {
            return _clientPassport;
        }

        public bool GetRegistration()
        {
            return _clientFinishedRegistration;
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
            private bool _clientFinishedRegistration = false;

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
                if (_clientPassport != null && _clientAddress != null)
                {
                    _clientFinishedRegistration = true;
                }

                var client = new Client(_clientFirstName, _clientLastName, _clientAddress, _clientPassport, _clientFinishedRegistration);

                return client;
            }
        }
    }
}