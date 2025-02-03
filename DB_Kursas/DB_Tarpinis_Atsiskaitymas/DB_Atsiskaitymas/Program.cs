using DB_Atsiskaitymas.Managers;

namespace DB_Atsiskaitymas;

class Program
{
    static void Main(string[] args)
    {
        var appManager = new AppManager();
        appManager.Run();
    }
}
