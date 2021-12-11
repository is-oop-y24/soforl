using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public abstract class BankAccount : IObserver
    {
        private const int DayMonth = 30;
        protected BankAccount(double operation, double sum, Client client, Bank bank, DateTime dateFinishing)
        {
            Operation = operation;
            Sum = sum;
            Client = client;
            Bank = bank;
            Limit = bank.TransferLimit;
            Date = DateTime.Now;
            DateFinishing = dateFinishing;
            Transactions = new List<Transaction>();
            Transactions.Add(new Transaction(sum));
        }

        protected BankAccount(double sum, Client client, Bank bank, DateTime dateFinishing)
        {
            Sum = sum;
            Client = client;
            Bank = bank;
            Operation = bank.CheckPercentage(sum);
            Date = DateTime.Now;
            DateFinishing = dateFinishing;
            Limit = bank.TransferLimit;
            Transactions = new List<Transaction>();
            Transactions.Add(new Transaction(sum));
        }

        public double Operation { get; set; }
        public double Sum { get; protected set; }
        public Client Client { get; }
        public Bank Bank { get; }
        public double Limit { get; }
        public DateTime Date { get; private set; }
        public DateTime DateFinishing { get; }
        public List<Transaction> Transactions { get; }

        public double DepositMoney(double money)
        {
            Transactions.Add(new Transaction(money));
            Sum += money;
            return Sum;
        }

        public virtual double WithdrawPartMoney(double money)
        {
            if (Sum > 0 && Client.CheckRegistration())
            {
                Transactions.Add(new Transaction(money * (-1)));
                Sum -= money;
                return Sum;
            }

            if (Sum >= money && !Client.CheckRegistration() && Limit >= money)
            {
                Transactions.Add(new Transaction(money * (-1)));
                Sum -= money;
                return Sum;
            }

            throw new Exception("No  money on the account");
        }

        public virtual double TransferPartMoney(double money, BankAccount bankAccount)
        {
            if (Sum >= money && Client.CheckRegistration())
            {
                bankAccount.DepositMoney(money);
                Sum -= money;
                return Sum;
            }

            if (Sum >= money && !Client.CheckRegistration() && Limit >= money)
            {
                bankAccount.DepositMoney(money);
                Sum -= money;
                return Sum;
            }

            throw new Exception("Invalid operation");
        }

        public virtual double CalculatePercentage(DateTime date)
        {
            double allPercentages = 0;
            if (DateFinishing >= date)
            {
                TimeSpan date2 = date - Date;
                int days = date2.Days;
                for (int i = 0; i < days; i++)
                {
                    allPercentages += Sum * (Operation / 365);
                    if (i == DayMonth)
                    {
                        Sum += allPercentages;
                        Transactions.Add(new Transaction(allPercentages));
                        days -= DayMonth;
                        i -= DayMonth;
                        allPercentages = 0;
                    }
                }
            }
            else
            {
                TimeSpan date2 = DateFinishing - Date;
                for (int i = 0; i < date2.Days; i++)
                {
                    allPercentages += Sum * (Operation / (365 * 100));
                    Sum += allPercentages;
                    Transactions.Add(new Transaction(allPercentages));
                    allPercentages = 0;
                }
            }

            Date = date;

            return Sum;
        }

        public abstract double CalculateCommission(DateTime date);

        public abstract double ChangePercentage(double newPercentage);
        public abstract double ChangeCommission(double newCommission);
        public virtual void Update(BankAccount account, double operation)
        {
            account.ChangePercentage(operation);
        }
    }
}