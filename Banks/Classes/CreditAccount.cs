using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CreditAccount : BankAccount
    {
        private double _initialSum;
        private int _daysCommission;

        public CreditAccount(double commission, double sum, Client client, Bank bank, DateTime dateFinishing, int daysCommission)
            : base(commission, sum, client, bank, dateFinishing)
        {
            _initialSum = sum;
            _daysCommission = daysCommission;
        }

        public override double CalculatePercentage(DateTime date)
        {
            throw new Exception("Invalid operation");
        }

        public override double CalculateCommission(DateTime date)
        {
            TimeSpan date2 = date - Date;
            int days = date2.Days;
            if (Sum < _initialSum && days - _daysCommission < 0)
            {
                for (int i = 0; i < Math.Abs(days - _daysCommission); i++)
                {
                    Sum -= _initialSum * (Operation / 100);
                    Transactions.Add(new Transaction(_initialSum * (Operation / 100) * (-1)));
                }

                _daysCommission -= days;
            }

            return Sum;
        }

        public override double ChangeCommission(double newCommission)
        {
            Operation = newCommission;
            return Operation;
        }

        public override double ChangePercentage(double newPercentage)
        {
            throw new Exception("Invalid operation");
        }
    }
}