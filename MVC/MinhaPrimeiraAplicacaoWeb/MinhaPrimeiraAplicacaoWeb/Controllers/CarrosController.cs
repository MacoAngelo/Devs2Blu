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

            var carros = Carro.GetAll();

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

        public IActionResult Record(long id)
        {
            //var carroAtual = _Carros.FirstOrDefault(carro => carro.ID == id);

            return View(null);
        }
    }
}
