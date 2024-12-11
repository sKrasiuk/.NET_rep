using Bankomatas.Interfaces;

namespace Bankomatas.Models
{
    public class BankCard : IBankCard
    {
        public Guid CardId { get; set; }
        public string CardName { get; set; }
        public decimal CardBalance { get; set; }
        public decimal[] Transactions { get; set; }
        public decimal MaxWithdrawValue { get; set; }
        public string Password { get; set; }
        public DateTime LastResetDate { get; set; }
        public int TransactionIndex { get; set; }

        public BankCard(string cardName, decimal cardBalance, string password)
        {
            CardName = cardName;
            CardBalance = cardBalance;
            Password = password;
            CardId = Guid.NewGuid();
            MaxWithdrawValue = 1000m;
            Transactions = new decimal[10];
            LastResetDate = DateTime.Now.Date;
            TransactionIndex = 0;
        }
    }
}
