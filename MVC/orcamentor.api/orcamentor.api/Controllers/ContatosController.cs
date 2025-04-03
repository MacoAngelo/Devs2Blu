using Microsoft.AspNetCore.Mvc;

namespace orcamentor.api.Controllers
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
    }

    public class ContatosController : Controller
    {
        [HttpGet("api/Contatos")]
        public IActionResult GetContatos()
        {
            var contatos = new List<Contato>()
            {
                new Contato() { Nome = "Marco A. Angelo", Email = "marco.angelo@prof.sc.senac.br", Numero = "+55 47 9 99171-0879"},
                new Contato() { Nome = "Maria", Email = "marco.angelo@prof.sc.senac.br", Numero = "+55 47 9 99171-0879"},
                new Contato() { Nome = "João", Email = "marco.angelo@prof.sc.senac.br", Numero = "+55 47 9 99171-0879"},
                new Contato() { Nome = "Pedro", Email = "marco.angelo@prof.sc.senac.br", Numero = "+55 47 9 99171-0879"},
                new Contato() { Nome = "Thiago", Email = "marco.angelo@prof.sc.senac.br", Numero = "+55 47 9 99171-0879"},
            };

            return Ok(contatos);
        }
    }
}
