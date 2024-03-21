using SistemaRepositorio.Models;

namespace SistemaRepositorio.Repositories.Interfaces
{
	public interface IRepositorioRepository
	{
		List<RepositorioModel> BuscarTodosRepositorios(string filtro, bool isFav);
		RepositorioModel BuscarRepositorioPorId(int id);
		void SalvarRepositorio(RepositorioModel repositorio);
		void AtualizarRepositorio(RepositorioModel repositorio, int id);
		void ExcluirRepositorio(int id);

	}
}
