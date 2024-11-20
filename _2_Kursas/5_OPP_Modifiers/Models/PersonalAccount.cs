namespace _5_OPP_Modifiers.Models
{
    public class PersonalAccount : Account
    {
        protected decimal Balance { get; private set; }
        public decimal OverdraftLimit { get; private set; }

        public override void SetBalance(decimal balance)
        {
            Balance = balance;
        }
        public void SetOverdraftLimit(decimal overdraftLimit)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override decimal GetBalance()
        {
            return Balance;
        }
        public decimal GetOverdraftLimit()
        {
            return OverdraftLimit;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Account balance: {Balance}");
            Console.WriteLine($"Overdraft limit: {OverdraftLimit}");
        }

        public decimal Withdraw()
        {
            decimal maxWithdrawValue = OverdraftLimit + Balance;
            return maxWithdrawValue;
        }
    }
}
