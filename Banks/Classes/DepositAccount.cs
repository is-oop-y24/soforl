using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class DepositAccount : BankAccount
    {
        public DepositAccount(double sum, Client client, Bank bank, DateTime dateFinishing)
            : base(sum, client, bank, dateFinishing)
        {
        }

        public override double WithdrawPartMoney(double money)
        {
            throw new Exception("Invalid operation");
        }

        public override double TransferPartMoney(double money, BankAccount bankAccount)
        {
            throw new Exception("Invalid operation");
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