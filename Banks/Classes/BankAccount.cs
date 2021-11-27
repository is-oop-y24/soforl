using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public abstract class BankAccount : IObservable
    {
        private List<IObserver> _observers;
        private double _percentage;
        private double _sum;
        private Client _client;
        private Bank _bank;
        private double _limit;
        private DateTime _dateCreation;
        private DateTime _dateFinishing;
        private List<Transaction> _transactions;

        protected BankAccount(double operation, double sum, Client client, Bank bank, DateTime dateFinishing)
        {
            _percentage = operation;
            _sum = sum;
            _client = client;
            _bank = bank;
            _limit = bank.GetTransferLimit();
            _dateCreation = DateTime.Now;
            _dateFinishing = dateFinishing;
            _observers = new List<IObserver>();
            AddObserver(bank);
            _transactions = new List<Transaction>();
            _transactions.Add(new Transaction(sum));
        }

        protected BankAccount(double sum, Client client, Bank bank, DateTime dateFinishing)
        {
            _sum = sum;
            _client = client;
            _bank = bank;
            _percentage = bank.CheckPercentage(sum);
            _dateCreation = DateTime.Now;
            _dateFinishing = dateFinishing;
            _limit = bank.GetTransferLimit();
            _observers = new List<IObserver>();
            AddObserver(bank);
            _transactions = new List<Transaction>();
            _transactions.Add(new Transaction(sum));
        }

        public abstract double DepositMoney(double money);
        public abstract double WithdrawPartMoney(double money);
        public abstract double TransferPartMoney(double money, BankAccount bankAccount);
        public abstract double GetCommission();
        public abstract double GetPercentage();
        public abstract double CalculatePercentage(DateTime date);
        public abstract double CalculateCommission(DateTime date);

        public abstract double ChangePercentage(double newPercentage);
        public abstract double ChangeCommission(double newCommission);
        public abstract double GetSum();
        public abstract List<Transaction> GetTransactions();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
            {
                observer.NotifyPercentageChanges(this);
            }
        }

        public Client GetClient()
        {
            return _client;
        }

        public Bank GetBank()
        {
            return _bank;
        }
    }
}