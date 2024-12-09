using Bankomatas.Interfaces;

namespace Bankomatas.Models
{
    public class BankCard : IBankCard
    {
        public Guid CardId { get; private set; }
        public string CardName { get; private set; }
        public decimal CardBalance { get; private set; }
        public decimal[] Transactions { get; private set; }
        public decimal MaxWithdrawValue { get; private set; }

        private int transactionIndex = 0;
        private DateTime lastResetDate;

        public BankCard(string cardName, decimal cardBalance)
        {
            CardName = cardName;
            CardBalance = cardBalance;
            CardId = Guid.NewGuid();
            MaxWithdrawValue = 1000;
            Transactions = new decimal[10];
            lastResetDate = DateTime.Now.Date;
        }

        public void WithdrawMoney(decimal withdrawAmount)
        {
            ResetTransactionsCounterOnNewDay();
            bool isPossibleToWithdraw = false;

            while (!isPossibleToWithdraw)
            {
                if (withdrawAmount > MaxWithdrawValue)
                {
                    Console.WriteLine("The amount is over the maximum withdrawal limit.");
                    break;
                }
                else if (withdrawAmount <= 0)
                {
                    Console.WriteLine("The withdraw amount is 0 or less. Incorrect value input.");
                    break;
                }
                else if (withdrawAmount > CardBalance)
                {
                    Console.WriteLine("Withdraw amount is over the Card Balance");
                    break;
                }
                else
                {
                    if (transactionIndex >= Transactions.Length)
                    {
                        Console.WriteLine("Maximum transactions limit reached. Unable to perform an operation.");
                        break;
                    }
                    else
                    {
                        CardBalance -= withdrawAmount;
                        Transactions[transactionIndex] = -withdrawAmount;
                        transactionIndex++;
                        Console.WriteLine($"Withdrawal successful. Remaining balance: {CardBalance:C}");
                        isPossibleToWithdraw = true;
                    }
                }
            }
        }

        public void ShowTransactions()
        {
            Console.WriteLine("Transactions:");
            int start = Math.Max(0, transactionIndex - 5);

            for (int i = start; i < transactionIndex; i++)
            {
                Console.WriteLine($"\tOperation {i + 1}: {Transactions[i]:C}");
            }

            if (transactionIndex == 0)
            {
                Console.WriteLine($"\tNo operations to display.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Account balance:\n\t{CardBalance:C}");
        }

        private void ResetTransactionsCounterOnNewDay()
        {
            if (DateTime.Now.Date != lastResetDate)
            {
                lastResetDate = DateTime.Now.Date;
                transactionIndex = 0;
            }
        }
    }
}
