using Bankomatas.Models;

namespace Bankomatas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bCard1 = new BankCardServices(new BankCard("Sergej Krasiukov", 10000m, "bc123"));
            var bCard2 = new BankCardServices(new BankCard("Vardas Pavarde", 10000m, "bc123"));

            //Console.WriteLine(bCard1.CardId);
            //Console.WriteLine(bCard1.Transactions.Length);
            bCard1.ShowBalance();

            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.DepositMoney(930);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.DepositMoney(470);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.DepositMoney(150);

            bCard1.ShowTransactions();

            bCard1.ShowBalance();
        }
    }
}
