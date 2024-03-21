using System.Data.SqlClient;
namespace SistemaRepositorio.Data
{
    public static class ConnectionManager
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Server=192.168.15.178;User Id=sa;Password=1234;Database=PROJETOS";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
