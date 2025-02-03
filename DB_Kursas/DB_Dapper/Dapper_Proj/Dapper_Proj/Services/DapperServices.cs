using Microsoft.Data.SqlClient;
using Dapper;
using Dapper_Proj.Models;

namespace Dapper_Proj.Services;

public class DapperServices : IDisposable
{
    private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=MyFirstDB;Trusted_Connection=True;TrustServerCertificate=True";
    private readonly SqlConnection _sqlConnection;
    // using var connection = new SqlConnection(connectionString);
    public DapperServices()
    {
        _sqlConnection = new SqlConnection(connectionString);
        _sqlConnection.Open();
    }

    public void Dispose()
    {
        _sqlConnection.Dispose();
    }

    public List<Darbuotojas> GetAllData()
    {
        string query = "select * from DARBUOTOJAS";

        return _sqlConnection.Query<Darbuotojas>(query).ToList();
    }
}
