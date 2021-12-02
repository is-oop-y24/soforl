namespace Banks.Classes
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(BankAccount bankAccount, double operation);
    }
}