using System;

namespace Banks.Classes
{
    public class Transaction
    {
        private Guid _idTransaction;
        private DateTime _timeTransaction;
        private double _sumTransaction;

        public Transaction(double sum)
        {
            _idTransaction = Guid.NewGuid();
            _timeTransaction = DateTime.Now;
            _sumTransaction = sum;
        }

        public double GetSumTransaction()
        {
            return _sumTransaction;
        }
    }
}