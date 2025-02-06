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
    }
}
