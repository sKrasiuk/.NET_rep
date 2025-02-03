using Dapper_Proj.Services;

namespace Dapper_Proj;

class Program
{
    static void Main(string[] args)
    {
        using var dapperServices = new DapperServices();
        var t = dapperServices.GetAllData();
        var v = dapperServices.GetAllData();
    }
}