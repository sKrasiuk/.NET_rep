namespace Bankomatas.Interfaces
{
    public interface IBankCard
    {
        Guid CardId { get; set; }
        string CardName { get; set; }
        decimal CardBalance { get; set; }
        decimal[] Transactions { get; set; }
        decimal MaxWithdrawValue { get; set; }
        string Password { get; set; }
        public DateTime LastResetDate { get; set; }
        public int TransactionIndex { get; set; }
    }
}
