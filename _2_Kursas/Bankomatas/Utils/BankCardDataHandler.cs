using Bankomatas.Models;
using System.Text.Json;

namespace Bankomatas.Utils
{
    public static class BankCardDataHandler
    {
        private static readonly string FilePath = "bankCards.json";

        public static List<BankCard> LoadBankCards()
        {
            if (!File.Exists(FilePath))
            {
                return new List<BankCard>();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<BankCard>> (json) ?? new List<BankCard>();
        }

        public static void SaveBankCards(List<BankCard> bankCards)
        {
            var json = JsonSerializer.Serialize(bankCards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static void AddUpdateBankCard(BankCard bankCard)
        {
            var bankCards = LoadBankCards();
            var existingBankCard = bankCards.FirstOrDefault(card => card.CardName == bankCard.CardName);

            if (existingBankCard != null)
            {
                bankCards.Remove(existingBankCard);
            }
            bankCards.Add(bankCard);
            SaveBankCards(bankCards);
        }

        //public static void RemoveBankCard(BankCard bankCard)
        //{
        //    var bankCards = LoadBankCards();
        //    var cardToRemove = bankCards.FirstOrDefault(card => card.CardName == card.CardName);

        //    if (cardToRemove != null)
        //    {
        //        bankCards.Remove(cardToRemove);
        //        SaveBankCards(bankCards);
        //    }
        //}
    }
}
