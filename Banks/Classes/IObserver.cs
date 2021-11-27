namespace Banks.Classes
{
    public interface IObserver
    {
        public void NotifyPercentageChanges(BankAccount bankAccount);
    }
}