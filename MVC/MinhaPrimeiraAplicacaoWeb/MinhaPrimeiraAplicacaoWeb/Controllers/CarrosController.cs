using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAplicacao.Utils.Entidades;
using MinhaPrimeiraAplicacaoWeb.Models.Carros;

namespace MinhaPrimeiraAplicacaoWeb.Controllers
{
    public class CarrosController : Controller
    {
        public IActionResult Index()
        {
            var model = new CarrosModel();
            model.Carros = new List<CarroModel>();

            var carros = new Carro().GetAll();

            // Mais Simples
            //foreach (var carro in carros)
            //{
            //    model.Carros.Add(new CarroModel()
            //    {
            //        ID = carro.ID,
            //        Nome = carro.Nome,
            //        Ano = carro.Ano,
            //        Placa = carro.Placa,
            //    });
            //}

            // Menos Simples
            //foreach (var carro in carros)
            //{
            //    model.Carros.Add(new CarroModel(carro));
            //}

            //Avançada
            model.Carros = carros.Select(carroEntidade => new CarroModel(carroEntidade)).ToList();

            return View(model);
        }

        public IActionResult Record(long? id)
        {
            var model = new CarroModel();

            if (id.HasValue)
            {
                model = new CarroModel(new Carro().Get(id.Value));
            }

            var marcas = new Marca().GetAll();
            model.MarcasDisponíveis = marcas.Select(marca => new Models.Marcas.MarcaModel(marca)).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Record(CarroModel model, string type)
        {
            Carro carro = model.GetEntidade();
            if (type == "save")
            {
                if (carro.ID > 0)
                {
                    carro.Update();
                }
                else
                {
                    carro.Create();
                }
            }
            else if (type == "delete")
            {
                carro.Delete();
            }
            else
            {
                return BadRequest("Requisição inválida!");
            }

            return RedirectToAction("Index");
        }

        [HttpGet("api/v1/Carros")]
        public IActionResult Get()
        {
            var result = new Carro().GetAll().Select(carro => new CarroModel(carro));

            return Ok(result);
        }

        [HttpPost("api/v1/Carro")]
        public IActionResult Post([FromBody] CarroModel carro)
        {
            var carroEntidade = carro.GetEntidade();
            carroEntidade.Create();

            return Ok("Carro cadastrado!");
        }

        [HttpPut("api/v1/Carro/{id}")]
        public IActionResult Put(long id, [FromBody] CarroModel carroAtualizado)
        {
            var carroDB = new Carro().Get(id);

            //if (carroDB.Nome != carroAtualizado.Nome)
            //{
            //    carroDB.Nome = carroAtualizado.Nome;
            //}

            carroDB.Nome = carroAtualizado.Nome ?? carroDB.Nome;
            carroDB.Ano = carroAtualizado.Ano ?? carroDB.Ano;
            carroDB.Categoria = carroAtualizado.Categoria ?? carroDB.Categoria;
            carroDB.Placa = carroAtualizado.Placa ?? carroDB.Placa;
            carroDB.Marca.ID = carroAtualizado?.Marca?.ID ?? carroDB.Marca.ID;

            carroDB.Update();

            return Ok("Carro atualizado!");
        }

        [HttpDelete("api/v1/Carros/{id}")]
        public IActionResult Delete(long id)
        {
            var carro = new Carro().Get(id);
            carro.Delete();

            return Ok("Carro deletado!");
        }
    }
}
