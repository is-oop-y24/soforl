using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class DepositAccount : BankAccount
    {
        private const int DayMonth = 30;
        private double _percentage;
        private double _sum;
        private Client _client;
        private Bank _bank;
        private DateTime _date;
        private DateTime _dateFinishing;
        private List<Transaction> _transactions;

        public DepositAccount(double sum, Client client, Bank bank, DateTime dateFinishing)
            : base(sum, client, bank, dateFinishing)
        {
            _percentage = bank.CheckPercentage(sum);
            _sum = sum;
            _client = client;
            _bank = bank;
            _date = DateTime.Now;
            _dateFinishing = dateFinishing;
            _transactions = new List<Transaction>();
            _transactions.Add(new Transaction(sum));
        }

        public override double DepositMoney(double money)
        {
            _transactions.Add(new Transaction(money));
            _sum += money;
            return _sum;
        }

        public override double WithdrawPartMoney(double money)
        {
            throw new Exception("Invalid operation");
        }

        public override double TransferPartMoney(double money, BankAccount bankAccount)
        {
            throw new Exception("Invalid operation");
        }

        public override double CalculatePercentage(DateTime date)
        {
            double allPercentages = 0;
            if (_dateFinishing >= date)
            {
                TimeSpan date2 = date - _date;
                int days = date2.Days;
                for (int i = 0; i < days; i++)
                {
                    allPercentages += _sum * (_percentage / (365 * 100));
                    if (i == DayMonth)
                    {
                        _sum += allPercentages;
                        _transactions.Add(new Transaction(allPercentages));
                        days -= DayMonth;
                        i -= DayMonth;
                        allPercentages = 0;
                    }
                }
            }
            else
            {
                TimeSpan date2 = _dateFinishing - _date;
                for (int i = 0; i < date2.Days; i++)
                {
                    allPercentages += _sum * (_percentage / (365 * 100));
                    _sum += allPercentages;
                    _transactions.Add(new Transaction(allPercentages));
                    allPercentages = 0;
                }
            }

            _date = date;

            return _sum;
        }

        public override double GetCommission()
        {
            throw new Exception("Invalid operation");
        }

        public override double GetPercentage()
        {
            return _percentage;
        }

        public override double ChangePercentage(double newPercentage)
        {
            _percentage = newPercentage;
            NotifyObservers();
            return _percentage;
        }

        public override double ChangeCommission(double newCommission)
        {
            throw new Exception("Invalid operation");
        }

        public override double CalculateCommission(DateTime date)
        {
            throw new Exception("Invalid operation");
        }

        public override List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public override double GetSum()
        {
            return _sum;
        }
    }
}