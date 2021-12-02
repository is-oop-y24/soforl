using System;

namespace Banks.Classes
{
    public class Transaction
    {
        public Transaction(double sum)
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now;
            Sum = sum;
        }

        public Guid Id { get; }
        public DateTime Time { get; }
        public double Sum { get; }
    }
}