using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class DebitAccount : BankAccount
    {
        public DebitAccount(double percentage, double sum, Client client, Bank bank, DateTime dateFinishing)
            : base(percentage, sum, client, bank, dateFinishing)
        {
        }

        public override double ChangePercentage(double newPercentage)
        {
            Operation = newPercentage;
            return Operation;
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