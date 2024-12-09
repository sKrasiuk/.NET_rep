using Bankomatas.Models;

namespace Bankomatas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bCard1 = new BankCard("Sergej Krasiukov", 10000);

            Console.WriteLine(bCard1.CardId);
            Console.WriteLine(bCard1.Transactions.Length);
            bCard1.ShowBalance();
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.WithdrawMoney(150);
            bCard1.ShowTransactions();
            bCard1.WithdrawMoney(150);

            Console.WriteLine(DateTime.Now.Date);
        }
    }
}
