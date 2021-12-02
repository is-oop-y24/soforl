using System.Collections.Generic;

namespace Banks.Classes
{
    public class Bank : IObservable
    {
        public Bank(string name, double transferLimit)
        {
            Name = name;
            Clients = new List<Client>();
            BankAccounts = new List<BankAccount>();
            TransferLimit = transferLimit;
            Percentages = new List<ConcretePercentageDepositAccount>();
            Observers = new List<IObserver>();
        }

        public List<Client> Clients { get; }
        public List<ConcretePercentageDepositAccount> Percentages { get; }
        public List<BankAccount> BankAccounts { get; }
        public double TransferLimit { get; private set; }
        public string Name { get; }
        public List<IObserver> Observers { get; }

        public List<BankAccount> GetBankAccounts()
        {
            return BankAccounts;
        }

        public double GetTransferLimit()
        {
            return TransferLimit;
        }

        public void AddPercentageSum(double percentage, double sumAccount)
        {
            double left = -1;
            double right = int.MaxValue;
            foreach (ConcretePercentageDepositAccount percentageDeposit in Percentages)
            {
                if (right > percentageDeposit.GetSum2() - sumAccount && right > 0
                    && left < sumAccount - percentageDeposit.GetSum2() && left < 0)
                {
                    left = sumAccount - percentageDeposit.GetSum2();
                    right = percentageDeposit.GetSum2() - sumAccount;
                }
            }

            var percentage2 = new ConcretePercentageDepositAccount(this, percentage, sumAccount - left, sumAccount);
            Percentages.Add(percentage2);
        }

        public double CheckPercentage(double sumAccount)
        {
            double left = -1;
            double right = int.MaxValue;
            double percentage = 0;
            foreach (ConcretePercentageDepositAccount percentageDeposit in Percentages)
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
            TransferLimit = newTransferLimit;
            return TransferLimit;
        }

        public void CancelTransaction(BankAccount bankAccount1, BankAccount bankAccount2, Transaction transaction)
        {
            foreach (Transaction item in bankAccount1.Transactions)
            {
                if (transaction.Id == item.Id)
                {
                    if (item.Sum > 0)
                    {
                        bankAccount1.WithdrawPartMoney(item.Sum);
                        bankAccount2.DepositMoney(item.Sum);
                        break;
                    }

                    if (item.Sum < 0)
                    {
                        bankAccount1.DepositMoney(item.Sum * (-1));
                        bankAccount2.WithdrawPartMoney(item.Sum * (-1));
                        break;
                    }
                }
            }
        }

        public void CancelTransaction(BankAccount bankAccount, Transaction transaction)
        {
            foreach (Transaction item in bankAccount.Transactions)
            {
                if (transaction.Id == item.Id)
                {
                    if (item.Sum > 0)
                    {
                        bankAccount.WithdrawPartMoney(item.Sum);
                        break;
                    }

                    if (item.Sum < 0)
                    {
                        bankAccount.DepositMoney(item.Sum * (-1));
                        break;
                    }
                }
            }
        }

        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers(BankAccount bankAccount, double operation)
        {
            foreach (IObserver observer in Observers)
            {
                observer.Update(bankAccount, operation);
            }
        }

        public List<Client> GetClients()
        {
            return Clients;
        }
    }
}