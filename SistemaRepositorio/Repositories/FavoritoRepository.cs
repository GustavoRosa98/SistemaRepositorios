using NuGet.Protocol.Core.Types;
using SistemaRepositorio.Data;
using SistemaRepositorio.Models;
using SistemaRepositorio.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SistemaRepositorio.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        public void AdicionarFavorito(int id)
        {
            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "INSERT INTO REPOSITORIOSFAVORITOS VALUES (" + id.ToString() +")";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível favoritar.");
            }
        }

        public void RemoverFavorito(int id)
        {
            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "DELETE FROM REPOSITORIOSFAVORITOS WHERE IdRepositorio = " + id.ToString();

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o favorito.");
            }
        }

        public bool VerificarFavorito(int id)
        {
            bool flgOK = false;
            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM REPOSITORIOSFAVORITOS WHERE IdRepositorio = " + id.ToString();
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    if((int)command.ExecuteScalar() > 0)
                    {
                        flgOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar o favorito.");
            }

            return flgOK;
        }
    }
}
