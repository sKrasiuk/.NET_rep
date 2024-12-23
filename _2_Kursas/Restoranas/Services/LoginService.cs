using System;
using Restoranas.Models;
using Restoranas.Repositories;

namespace Restoranas.Services;

public class LoginService
{
    private readonly WaitersRepository waitersRepository;

    public LoginService(WaitersRepository waitersRepository)
    {
        this.waitersRepository = waitersRepository;
    }

    public Waiter LogIn()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Available Waiters:");
            foreach (var w in waitersRepository)
            {
                Console.WriteLine($"{w.Id}. {w.Name}");
            }
            Console.WriteLine("\n0. Exit Application");

            Console.Write("\nEnter Waiter ID (0 to exit): ");
            if (int.TryParse(Console.ReadLine(), out int waiterId))
            {
                if (waiterId == 0)
                {
                    return null;
                }

                var waiter = waitersRepository.FirstOrDefault(w => w.Id == waiterId);
                if (waiter != null)
                {
                    Console.WriteLine($"Logged in as {waiter.Name}");
                    Console.ReadKey();
                    return waiter;
                }
            }
            Console.WriteLine("Invalid input. Please try again.");
            Console.ReadKey();
        }
    }
}
