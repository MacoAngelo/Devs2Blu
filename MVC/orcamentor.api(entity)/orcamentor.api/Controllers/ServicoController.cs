using Microsoft.AspNetCore.Mvc;

namespace orcamentor.api.Controllers
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public float Valor {  get; set; }
        public string Equipe { get; set; }
        public string Responsavel { get; set; }
    }

    public class ServicoController : Controller
    {
        [HttpGet("api/servicos")]
        public IActionResult GetServico()
        {
            var servicos = new List<Servico>()
            {
                new Servico() {Id = 1, Descricao = "Serviço 1", Valor = 22.5f, Equipe = "Jonas, Maria, Luiz", Responsavel = "Marco"},
                new Servico() {Id = 2, Descricao = "Serviço 2", Valor = 23.6f, Equipe = "Lucio, Mario, Luizo", Responsavel = "Marcão"},
                new Servico() {Id = 3, Descricao = "Serviço 3", Valor = 24.7f, Equipe = "Edinan, Maro, Roger", Responsavel = "Cardoso"}
            };
            return Ok(servicos);
        }
    }
}
