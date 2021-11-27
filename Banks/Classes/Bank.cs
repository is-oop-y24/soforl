using System.Collections.Generic;

namespace Banks.Classes
{
    public class Bank : IObserver
    {
        private List<Client> _clients;
        private List<ConcretePercentageDepositAccount> _percentages;
        private List<BankAccount> _bankAccounts;
        private double _transferLimit;
        private string _name;

        public Bank(string name, double transferLimit)
        {
            _name = name;
            _clients = new List<Client>();
            _bankAccounts = new List<BankAccount>();
            _transferLimit = transferLimit;
            _percentages = new List<ConcretePercentageDepositAccount>();
        }

        public List<BankAccount> GetBankAccounts()
        {
            return _bankAccounts;
        }

        public double GetTransferLimit()
        {
            return _transferLimit;
        }

        public void AddPercentageSum(double percentage, double sumAccount)
        {
            double left = -1;
            double right = int.MaxValue;
            foreach (ConcretePercentageDepositAccount percentageDeposit in _percentages)
            {
                if (right > percentageDeposit.GetSum2() - sumAccount && right > 0
                    && left < sumAccount - percentageDeposit.GetSum2() && left < 0)
                {
                    left = sumAccount - percentageDeposit.GetSum2();
                    right = percentageDeposit.GetSum2() - sumAccount;
                }
            }

            var percentage2 = new ConcretePercentageDepositAccount(this, percentage, sumAccount - left, sumAccount);
            _percentages.Add(percentage2);
        }

        public double CheckPercentage(double sumAccount)
        {
            double left = -1;
            double right = int.MaxValue;
            double percentage = 0;
            foreach (ConcretePercentageDepositAccount percentageDeposit in _percentages)
            {
                if (right > percentageDeposit.GetSum2() - sumAccount && right > 0
                    && left < sumAccount - percentageDeposit.GetSum2() && left < 0)
                {
                    left = sumAccount - percentageDeposit.GetSum2();
                    right = percentageDeposit.GetSum2() - sumAccount;
                    percentage = percentageDeposit.GetPercentage();
                }
            }

            return percentage;
        }

        public double ChangeTransferLimit(double newTransferLimit)
        {
            _transferLimit = newTransferLimit;
            return _transferLimit;
        }

        public void CancelTransaction(BankAccount bankAccount1, BankAccount bankAccount2, Transaction transaction)
        {
            foreach (Transaction item in bankAccount1.GetTransactions())
            {
                if (transaction == item)
                {
                    if (item.GetSumTransaction() > 0)
                    {
                        bankAccount1.WithdrawPartMoney(item.GetSumTransaction());
                        bankAccount2.DepositMoney(item.GetSumTransaction());
                        break;
                    }

                    if (item.GetSumTransaction() < 0)
                    {
                        bankAccount1.DepositMoney(item.GetSumTransaction() * (-1));
                        bankAccount2.WithdrawPartMoney(item.GetSumTransaction() * (-1));
                        break;
                    }
                }
            }
        }

        public void NotifyPercentageChanges(BankAccount bankAccount)
        {
            bankAccount.NotifyObservers();
        }
    }
}