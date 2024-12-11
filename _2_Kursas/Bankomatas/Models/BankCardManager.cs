namespace Bankomatas.Models
{
    public class BankCardManager
    {
        private readonly Authenticator Authentication;

        public BankCardManager()
        {
            Authentication = new Authenticator();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to ATM!");
            var bankCard = Authentication.AuthenticateUser("", "");

            if (bankCard != null)
            {
                var services = new BankCardServices(bankCard);
                ShowMenu(services);
            }
            else
            {
                Console.WriteLine("Authentication failed. Exiting...");
            }
        }

        private void ShowMenu(BankCardServices services)
        {
            bool exit = false;
            services.ShowBalance();

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Deposit Money");
                Console.WriteLine("2. Withdraw Money");
                Console.WriteLine("3. Show Transactions");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter deposit amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            Console.Clear();
                            services.DepositMoney(depositAmount);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter withdrawal amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            Console.Clear();
                            services.WithdrawMoney(withdrawAmount);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "3":
                        Console.Clear();
                        services.ShowTransactions();
                        break;

                    case "4":
                        Console.Clear();
                        services.ShowBalance();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
