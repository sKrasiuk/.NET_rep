namespace Bankomatas.Interfaces
{
    public interface IBankCardServices
    {
        void DepositMoney(decimal depositAmount);
        void WithdrawMoney(decimal withdrawAmount);
        void ShowTransactions();
        void ShowBalance();
    }
}
