using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class DebitAccount : BankAccount
    {
        private const int DayMonth = 30;
        private double _percentage;
        private DateTime _date;
        private DateTime _dateFinishing;
        private double _sum;
        private Client _client;
        private double _limit;
        private Bank _bank;
        private List<Transaction> _transactions;

        public DebitAccount(double percentage, double sum, Client client, Bank bank, DateTime dateFinishing)
            : base(percentage, sum, client, bank, dateFinishing)
        {
            _date = DateTime.Now;
            _dateFinishing = dateFinishing;
            _percentage = percentage;
            _sum = sum;
            _limit = bank.GetTransferLimit();
            _client = client;
            _bank = bank;
            _transactions = new List<Transaction>();
            _transactions.Add(new Transaction(sum));
        }

        public override double WithdrawPartMoney(double money)
        {
            if (_sum >= money && _client.GetRegistration())
            {
                _transactions.Add(new Transaction(money * (-1)));
                _sum -= money;
                return _sum;
            }

            if (_sum >= money && !_client.GetRegistration() && _limit >= money)
            {
                _transactions.Add(new Transaction(money * (-1)));
                _limit -= money;
                _sum -= money;
                return _sum;
            }

            throw new Exception("No money on the account");
        }

        public override double DepositMoney(double money)
        {
            _transactions.Add(new Transaction(money));
            _sum += money;
            return _sum;
        }

        public override double TransferPartMoney(double money, BankAccount bankAccount)
        {
            if (_sum >= money && _client.GetRegistration())
            {
                bankAccount.DepositMoney(money);
                _sum -= money;
                return _sum;
            }

            if (_sum >= money && !_client.GetRegistration() && _limit >= money)
            {
                bankAccount.DepositMoney(money);
                _limit -= money;
                _sum -= money;
                return _sum;
            }

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
                    allPercentages += _sum * (_percentage / 365);
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

        public override double GetSum()
        {
            return _sum;
        }

        public override List<Transaction> GetTransactions()
        {
            return _transactions;
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
    }
}