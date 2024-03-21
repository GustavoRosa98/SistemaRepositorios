using SistemaRepositorio.Models;

namespace SistemaRepositorio.Repositories.Interfaces
{
    public interface IFavoritoRepository
    {
        void AdicionarFavorito(int id);
        void RemoverFavorito(int id);
        bool VerificarFavorito(int id);
    }
}
