namespace Banks.Classes
{
    public class ConcretePercentageDepositAccount
    {
        private Bank _bank;
        private double _percentage;
        private double _lowerBorderSum;
        private double _upperBorderSum;

        public ConcretePercentageDepositAccount(Bank bank, double percentage, double lowerBorderSum, double upperBorderSum)
        {
            _bank = bank;
            _percentage = percentage;
            _upperBorderSum = upperBorderSum;
            _lowerBorderSum = lowerBorderSum;
        }

        public double GetSum2()
        {
            return _upperBorderSum;
        }

        public double GetSum1()
        {
            return _lowerBorderSum;
        }

        public double GetPercentage()
        {
            return _percentage;
        }
    }
}