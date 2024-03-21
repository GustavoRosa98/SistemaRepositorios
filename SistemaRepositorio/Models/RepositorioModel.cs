namespace SistemaRepositorio.Models
{
	public class RepositorioModel
	{
        public int IdRepositorio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Linguagem { get; set; }
        public DateTime DtUltimaAtt { get; set; }
        public string DonoRepositorio { get; set; }
    }
}
