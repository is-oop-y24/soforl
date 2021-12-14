namespace Banks.Classes
{
    public interface IObserver
    {
        void Update(BankAccount account, double operation);
    }
}