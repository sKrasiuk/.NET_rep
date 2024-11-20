namespace _5_OPP_Modifiers.Models
{
    internal class SavingsAccount : Account
    {
        protected decimal Balance { get; private set; }

        private double InterestRate { get; set; }

        public SavingsAccount(double interestRate)
        {
            InterestRate = interestRate;
        }

        public decimal CalculateInterest()
        {
            return Balance * (decimal)InterestRate;
        }

        public override void SetBalance(decimal balance)
        {
            Balance = balance;
        }

        public override decimal GetBalance()
        {
           return Balance;
        }
    }
}
