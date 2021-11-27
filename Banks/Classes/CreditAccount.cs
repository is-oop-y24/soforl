using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CreditAccount : BankAccount
    {
        private double _commission;
        private double _sum;
        private double _initialSum;
        private Client _client;
        private Bank _bank;
        private DateTime _date;
        private int _daysCommission;
        private double _limit;
        private DateTime _dateFinishing;
        private List<Transaction> _transactions;

        public CreditAccount(double commission, double sum, Client client, Bank bank, DateTime dateFinishing, int daysCommission)
            : base(commission, sum, client, bank, dateFinishing)
        {
            _commission = commission;
            _sum = sum;
            _initialSum = sum;
            _client = client;
            _bank = bank;
            _limit = bank.GetTransferLimit();
            _date = DateTime.Now;
            _dateFinishing = dateFinishing;
            _daysCommission = daysCommission;
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
            if (_sum > 0 && _client.GetRegistration())
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

            throw new Exception("No  money on the account");
        }

        public override double TransferPartMoney(double money, BankAccount bankAccount)
        {
            if (_client.GetRegistration() && _sum >= money)
            {
                bankAccount.DepositMoney(money * (-1));
                _sum -= money;
                return _sum;
            }

            if (_sum >= money && !_client.GetRegistration() && _limit >= money)
            {
                bankAccount.DepositMoney(money * (-1));
                _sum -= money;
                _limit -= money;
                return _sum;
            }

            throw new Exception("Invalid operation");
        }

        public override double CalculatePercentage(DateTime date)
        {
            throw new Exception("Invalid operation");
        }

        public override double CalculateCommission(DateTime date)
        {
            TimeSpan date2 = date - _date;
            int days = date2.Days;
            if (_sum < _initialSum && days - _daysCommission < 0)
            {
                for (int i = 0; i < Math.Abs(days - _daysCommission); i++)
                {
                    _sum -= _initialSum * (_commission / 100);
                    _transactions.Add(new Transaction(_initialSum * (_commission / 100) * (-1)));
                }

                _daysCommission -= days;
            }

            return _sum;
        }

        public override double ChangeCommission(double newCommission)
        {
            _commission = newCommission;
            NotifyObservers();
            return _commission;
        }

        public override double GetCommission()
        {
            return _commission;
        }

        public override double GetPercentage()
        {
            throw new Exception("Invalid operation");
        }

        public override double ChangePercentage(double newPercentage)
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