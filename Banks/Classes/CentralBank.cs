using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _banks = new List<Bank>();

        public Bank RegisterBank(string name, double limit)
        {
            var bank = new Bank(name, limit);
            _banks.Add(bank);
            return bank;
        }

        public void ScrollingTime(DateTime date)
        {
            foreach (Bank bank in _banks)
            {
                foreach (BankAccount bankAccount in bank.BankAccounts)
                {
                    bankAccount.CalculatePercentage(date);
                }
            }
        }

        public List<Bank> GetBanks()
        {
            return _banks;
        }
    }
}