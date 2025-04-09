using Microsoft.AspNetCore.Mvc;
using orcamentor.api.Model;
using orcamentor.api.Model.Repository.Interfaces;

namespace orcamentor.api.Controllers
{

    [ApiController]
    public class ContatosController : ControllerBase
    {
        //private readonly IContatoRepository _repository;
        private readonly ICarroRepository _repositoryCarros;

        public ContatosController(/*IContatoRepository repository, */ICarroRepository repositoryCarros)
        {
            //_repository = repository;
            _repositoryCarros = repositoryCarros;
        }

        [HttpGet("api/contatos")]
        public IActionResult GetContatos()
        {
            //var consultaContato = _repository.Listar().Result;

            var carrinhos = _repositoryCarros.Listar();
            return Ok(carrinhos);
        }

        //[HttpGet("api/contatos/{id}")]
        //public IActionResult GetContatosID (int id)
        //{
        //    var consultaContato = _repository.BuscarPorId(id).Result;

        //    if (consultaContato == null)
        //    {
        //        return NotFound();        
        //    }

        //    return Ok(consultaContato); 
        //}

        //[HttpPost("api/contatos")]
        //public IActionResult Salvar(Contato contato)
        //{
        //    _repository.Salvar(contato);
        //    return Ok();
        //}
    }
}
