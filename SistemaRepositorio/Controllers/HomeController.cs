using Microsoft.AspNetCore.Mvc;
using SistemaRepositorio.Models;
using SistemaRepositorio.Repositories;
using SistemaRepositorio.Repositories.Interfaces;
using System.Diagnostics;

namespace SistemaRepositorio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioRepository _repositorioRepository;
        private readonly IFavoritoRepository _favoritoRepository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repositorioRepository = new RepositorioRepository();
            _favoritoRepository = new FavoritoRepository();
        }

        public IActionResult Index()
        {
            List<RepositorioModel> listaReps = new List<RepositorioModel>();
            //RepositorioModel rep = new RepositorioModel();

            //rep.Nome = "Insercao teste";
            //rep.Descricao = "Desc teste";
            //rep.Linguagem = "Ling teste";
            //rep.DtUltimaAtt = DateTime.Now;
            //rep.DonoRepositorio = "Dono teste";

            //_repositorioRepository.SalvarRepositorio(rep);

            return View();
        }

        public IActionResult PartialViewTabelaRepositorios(string filtro = "", bool isFav = false)
        {
            List<RepositorioModel> listaReps = new List<RepositorioModel>();

            listaReps = _repositorioRepository.BuscarTodosRepositorios(filtro, isFav);

            ViewBag.listaReps = listaReps;

            return PartialView("PVTabelaRepositorios");
        }

        public IActionResult FormRepositorio()
        {
            return View();
        }

        public IActionResult DetalhesRepositorio(int idRepositorio)
        {
            RepositorioModel repositorio = _repositorioRepository.BuscarRepositorioPorId(idRepositorio);
            bool isFavorito = _favoritoRepository.VerificarFavorito(idRepositorio);
            ViewBag.repositorio = repositorio;
            ViewBag.favorito = isFavorito;
            return View();
        }

        public IActionResult MudarFavorito(int idRepositorio)
        {
            bool isFavorito = _favoritoRepository.VerificarFavorito(idRepositorio);
            if (isFavorito)
                _favoritoRepository.RemoverFavorito(idRepositorio);
            else
                _favoritoRepository.AdicionarFavorito(idRepositorio);

            return RedirectToAction("DetalhesRepositorio", new { idRepositorio = idRepositorio });
        }

        public IActionResult SalvarRepositorio(RepositorioModel repositorio)
        {
            _repositorioRepository.SalvarRepositorio(repositorio);
            return RedirectToAction("Index");
        }

        public void ExcluirRepositorio(int IdRepositorio)
        {
            _repositorioRepository.ExcluirRepositorio(IdRepositorio);
            _favoritoRepository.RemoverFavorito(IdRepositorio);
        }
    }
}
