using System;
using Restoranas.Models;
using Restoranas.Repositories;

namespace Restoranas.Services;

public class LoginService
{
    // private List<Waiter> waiters;

    // public LoginService(List<Waiter> waiters)
    // {
    //     this.waiters = waiters;
    // }
    private readonly WaitersRepository waitersRepository;

    public LoginService(WaitersRepository waitersRepository)
    {
        this.waitersRepository = waitersRepository;
    }

    public Waiter LogIn()
    {
        Waiter waiter = null;

        while (waiter == null)
        {
            Console.Clear();
            Console.WriteLine("Available Waiters:");
            foreach (var w in waitersRepository)
            {
                Console.WriteLine($"{w.Id}. {w.Name}");
            }

            Console.Write("Enter Waiter ID to log in: ");
            if (int.TryParse(Console.ReadLine(), out int waiterId))
            {
                waiter = waitersRepository.FirstOrDefault(w => w.Id == waiterId);
                if (waiter == null)
                {
                    Console.WriteLine("Invalid waiter ID.");
                }
                else
                {
                    Console.WriteLine($"Logged in as {waiter.Name}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid waiter ID.");
            }
        }

        return waiter;
    }
}
