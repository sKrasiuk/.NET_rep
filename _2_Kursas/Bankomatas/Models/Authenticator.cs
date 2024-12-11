using Bankomatas.Utils;

namespace Bankomatas.Models
{
    public class Authenticator
    {
        private const int MaxAttempts = 3;
        public BankCard AuthenticateUser(string cardName, string password)
        {
            int attempts = 0;
            Guid insertedCardId = CardInsertion();

            var bankCards = BankCardDataHandler.LoadBankCards();
            var bankCard = bankCards.FirstOrDefault(card => card.CardId == insertedCardId);

            if (bankCard == null)
            {
                Console.WriteLine("Invalid BANK CARD.");
                return null;
            }
            Console.WriteLine("BANK CARD recognized. Please proceed.");

            while (attempts < MaxAttempts)
            {
                Console.WriteLine("Enter Card name and Password.");
                Console.Write("Card name: ");
                cardName = Console.ReadLine()?.ToLower().Trim().Replace(" ", "");
                Console.Write("Password: ");
                password = Console.ReadLine();

                if (bankCard != null && bankCard.CardName.ToLower().Trim().Replace(" ", "") == cardName && bankCard.Password == password)
                {
                    Console.Clear();
                    Console.WriteLine("Login successful!\n");
                    ResetTransactionsCounterOnNewDay(bankCard);
                    return bankCard;
                }

                attempts++;
                if (attempts < MaxAttempts)
                {
                    Console.WriteLine($"Invalid credentials. You have {MaxAttempts - attempts} attempts remaining.");
                }
                else
                {
                    Console.WriteLine("Maximum login attempts reached. Access denied.");
                }
            }
            return null;
        }

        private Guid CardInsertion()
        {
            Console.Write("Insert bank card (input GUID): ");
            string providedGuid = Console.ReadLine();

            if (!Guid.TryParse(providedGuid, out Guid cardGuid))
            {
                Console.WriteLine("Invalid BANK CARD. Terminating...");
                Environment.Exit(0);
            }

            return cardGuid;
        }

        private void ResetTransactionsCounterOnNewDay(BankCard bankCard)
        {
            if (DateTime.Now.Date != bankCard.LastResetDate)
            {
                bankCard.LastResetDate = DateTime.Now.Date;
                bankCard.TransactionIndex = 0;
                BankCardDataHandler.AddUpdateBankCard(bankCard);
            }
        }
    }
}
