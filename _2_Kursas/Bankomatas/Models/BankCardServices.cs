using Bankomatas.Interfaces;
using Bankomatas.Utils;

namespace Bankomatas.Models
{
    public class BankCardServices : IBankCardServices
    {
        private BankCard BankCard { get; set; }
        private int transactionIndex;

        public BankCardServices(BankCard bankCard)
        {
            BankCard = bankCard;
            transactionIndex = BankCard.TransactionIndex;
            BankCardDataHandler.AddUpdateBankCard(bankCard);
        }

        //private int transactionIndex = 0;
        //private DateTime lastResetDate;

        public void DepositMoney(decimal depositAmount)
        {
            ResetTransactionsCounterOnNewDay();

            if (depositAmount <= 0)
            {
                Console.WriteLine("The deposit amount is 0 or less. Incorrect value input.");
            }
            else if (transactionIndex >= BankCard.Transactions.Length)
            {
                Console.WriteLine("Maximum transactions limit reached. Unable to perform an operation.");
            }
            else
            {
                BankCard.CardBalance += depositAmount;
                BankCard.Transactions[transactionIndex] = depositAmount;
                transactionIndex++;
                BankCard.TransactionIndex = transactionIndex;
                BankCardDataHandler.AddUpdateBankCard(BankCard);
                Console.WriteLine($"Deposit successful. Remaining balance: {BankCard.CardBalance:C}");
            }
        }

        public void WithdrawMoney(decimal withdrawAmount)
        {
            ResetTransactionsCounterOnNewDay();

            if (withdrawAmount > BankCard.MaxWithdrawValue)
            {
                Console.WriteLine("The amount is over the maximum withdrawal limit.");
            }
            else if (withdrawAmount <= 0)
            {
                Console.WriteLine("The withdraw amount is 0 or less. Incorrect value input.");
            }
            else if (withdrawAmount > BankCard.CardBalance)
            {
                Console.WriteLine("Withdraw amount is over the Card Balance");
            }
            else
            {
                if (transactionIndex >= BankCard.Transactions.Length)
                {
                    Console.WriteLine("Maximum transactions limit reached. Unable to perform an operation.");
                }
                else
                {
                    BankCard.CardBalance -= withdrawAmount;
                    BankCard.Transactions[transactionIndex] = -withdrawAmount;
                    transactionIndex++;
                    BankCard.TransactionIndex = transactionIndex;
                    BankCardDataHandler.AddUpdateBankCard(BankCard);
                    Console.WriteLine($"Withdrawal successful. Remaining balance: {BankCard.CardBalance:C}");
                }
            }
        }

        public void ShowTransactions()
        {
            Console.WriteLine($"Transactions: [{BankCard.Transactions.Length - BankCard.TransactionIndex}/{BankCard.Transactions.Length}]");
            int start = Math.Max(0, transactionIndex - 5);

            for (int i = start; i < transactionIndex; i++)
            {
                Console.WriteLine($"\tOperation {i + 1}: {BankCard.Transactions[i]:C}");
            }

            if (transactionIndex == 0)
            {
                Console.WriteLine($"\tNo operations to display.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Account balance:\n\t{BankCard.CardBalance:C}");
        }

        private void ResetTransactionsCounterOnNewDay()
        {
            if (DateTime.Now.Date != BankCard.LastResetDate)
            {
                BankCard.LastResetDate = DateTime.Now.Date;
                transactionIndex = 0;
                BankCard.TransactionIndex = transactionIndex;
                BankCardDataHandler.AddUpdateBankCard(BankCard);
            }
        }
    }
}
