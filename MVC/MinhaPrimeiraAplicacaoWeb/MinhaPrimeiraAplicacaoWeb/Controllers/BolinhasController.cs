using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraAplicacaoWeb.Controllers
{
    public class Bolinha
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }

    public class BolinhasController : Controller
    {
        private static List<Bolinha> _Bolinhas = new List<Bolinha>();

        [HttpGet("api/v1/bolinhas")]
        public IActionResult Get()
        {
            return Ok(_Bolinhas);
        }

        [HttpPost("api/v1/bolinha")]
        public IActionResult Post([FromBody] Bolinha bolinha)
        {
            bolinha.Id = Guid.NewGuid();
            _Bolinhas.Add(bolinha);

            Thread.Sleep(5000);

            return Ok(bolinha.Id);
        }

        [HttpDelete("api/v1/bolinha/{idBolinha}")]
        public IActionResult Delete(Guid idBolinha)
        {
            _Bolinhas.RemoveAll(bolinha => bolinha.Id == idBolinha); //LINQ

            return Ok("Registro excluído!");
        }
    }
}
