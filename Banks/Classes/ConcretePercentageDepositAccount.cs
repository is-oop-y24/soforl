namespace Banks.Classes
{
    public class ConcretePercentageDepositAccount
    {
        private Bank _bank;
        private double _percentage;
        private double _sum1;
        private double _newSum;

        public ConcretePercentageDepositAccount(Bank bank, double percentage, double sum1, double sum2)
        {
            _bank = bank;
            _percentage = percentage;
            _newSum = sum2;
            _sum1 = sum1;
        }

        public double GetSum2()
        {
            return _newSum;
        }

        public double GetSum1()
        {
            return _sum1;
        }

        public double GetPercentage()
        {
            return _percentage;
        }
    }
}