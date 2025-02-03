using System.Data;
using Dapper;
using Dapper_DB.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_DB;

class Program
{
    static void Main(string[] args)
    {
        var query = "select * from [DARBUOTOJAS]";
        var connectionString = "Server=localhost\\SQLEXPRESS;Database=MyFirstDB;Trusted_Connection=True;TrustServerCertificate=True";

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var data = connection.Query<Darbuotojas>(query);

        var spQuery = "execute GetDarbuotojasByAsmensKodas @AsmensKodas";
        var spParams = new { AsmensKodas = "38101122335" };
        var spName = "[MyFirstDB].dbo.[GetDarbuotojasByAsmensKodas]";
        var spResult = connection.QueryFirst<Darbuotojas>(spQuery, spParams);
        var spResult2 = connection.QueryFirst<Darbuotojas>(spName, spParams, commandType: CommandType.StoredProcedure);
        var query2 =  "select * from darbuotojas d where Vardas = @Vardas";
        var queryResult = connection.Query<Darbuotojas>(query2, new{vardas = "Jonas"}); 
    }
}
