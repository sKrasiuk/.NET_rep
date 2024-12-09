namespace Bankomatas.Interfaces
{
    public interface IBankCard
    {
        Guid CardId { get; }
        string CardName { get; }
        decimal CardBalance { get; }
        decimal[] Transactions { get; }
        decimal MaxWithdrawValue { get; }

        void WithdrawMoney(decimal withdrawAmount);
        void ShowTransactions();
        void ShowBalance();
    }
}
