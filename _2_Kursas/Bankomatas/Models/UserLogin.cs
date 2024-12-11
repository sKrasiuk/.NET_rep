using Bankomatas.Utils;

namespace Bankomatas.Models
{
    public class UserLogin
    {
        private const int MaxAttempts = 3;

        public BankCard AuthenticateUser(string cardName, string password)
        {
            int attempts = 0;

            while (attempts < MaxAttempts)
            {
                var bankCards = BankCardDataHandler.LoadBankCards();
                var bankCard = bankCards.FirstOrDefault(card => card.CardName.ToLower() == cardName.ToLower());

                if (bankCard != null && bankCard.Password == password)
                {
                    Console.WriteLine("Login successful!");
                    return bankCard;
                }

                attempts++;
                if (attempts < MaxAttempts)
                {
                    Console.WriteLine($"Invalid credentials. You have {MaxAttempts - attempts} attempts remaining.");
                    Console.WriteLine("Enter card name and password:");
                    Console.Write("Card name: ");
                    cardName = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Maximum login attempts reached. Access denied.");
                }
            }

            return null;
        }
    }
}
