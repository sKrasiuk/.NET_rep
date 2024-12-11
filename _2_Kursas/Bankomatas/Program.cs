using Bankomatas.Models;

namespace Bankomatas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new BankCardManager();
            manager.Start();
        }
    }
}
