using SistemaRepositorio.Data;
using SistemaRepositorio.Models;
using SistemaRepositorio.Repositories.Interfaces;
using System.Data.SqlClient;
using System.Linq;

namespace SistemaRepositorio.Repositories
{
	public class RepositorioRepository : IRepositorioRepository
	{		
		public void AtualizarRepositorio(RepositorioModel repositorio, int id)
		{
			throw new NotImplementedException();
		}

		public RepositorioModel BuscarRepositorioPorId(int id)
		{
            RepositorioModel rep = new RepositorioModel();

            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "SELECT * FROM TABELAREPOSITORIOS WHERE IdRepositorio = " + id.ToString();
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rep = new RepositorioModel();
                            rep.IdRepositorio = Convert.ToInt32(reader["IdRepositorio"]);
                            rep.Nome = reader["Nome"].ToString();
                            rep.Descricao = reader["Descricao"].ToString();
                            rep.Linguagem = reader["Linguagem"].ToString();
                            rep.DtUltimaAtt = Convert.ToDateTime(reader["DtUltimaAtt"]);
                            rep.DonoRepositorio = reader["DonoRepositorio"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar buscar o Repositório");
            }

            return rep;
        }

		public List<RepositorioModel> BuscarTodosRepositorios(string filtro = "", bool isFav = false)
		{
			List<RepositorioModel> listaRepositorios = new List<RepositorioModel>();
			RepositorioModel rep = new RepositorioModel();

			try
			{
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "";

                    if (!isFav)
                         query = "SELECT * FROM TABELAREPOSITORIOS WHERE Nome LIKE '%"+ filtro +"%'";
                    else
                         query = "SELECT R.* FROM TABELAREPOSITORIOS R " +
                        "INNER JOIN REPOSITORIOSFAVORITOS F ON R.IdRepositorio = F.IdRepositorio";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rep = new RepositorioModel();
                            rep.IdRepositorio = Convert.ToInt32(reader["IdRepositorio"]);
                            rep.Nome = reader["Nome"].ToString();
                            rep.Descricao = reader["Descricao"].ToString();
                            rep.Linguagem = reader["Linguagem"].ToString();
                            rep.DtUltimaAtt = Convert.ToDateTime(reader["DtUltimaAtt"]);
                            rep.DonoRepositorio = reader["DonoRepositorio"].ToString();
                            listaRepositorios.Add(rep);
                        }
                    }
                }
            }
			catch(Exception ex)
			{
                throw new Exception("Erro ao tentar buscar os Repositórios");
            }          

			return listaRepositorios;
        }

        public void ExcluirRepositorio(int id)
		{
            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "DELETE FROM TABELAREPOSITORIOS WHERE IdRepositorio = " + id.ToString();

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar o repositório");
            }
        }

		public void SalvarRepositorio(RepositorioModel repositorio)
		{
            try
            {
                using (SqlConnection connection = ConnectionManager.GetConnection())
                {
                    string query = "INSERT INTO TABELAREPOSITORIOS VALUES ('"
                        + repositorio.Nome + "', '"
                        + repositorio.Descricao + "', '"
                        + repositorio.Linguagem + "', '"
                        + repositorio.DtUltimaAtt + "', '"
                        + repositorio.DonoRepositorio + "')";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possível inserir o repositório");
            }
            

        }
	}
}
