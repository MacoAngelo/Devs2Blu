using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAplicacaoWeb.Models.Carros;

namespace MinhaPrimeiraAplicacaoWeb.Controllers
{
    public class CarrosController : Controller
    {
        public List<CarroModel> _Carros = new List<CarroModel>() {
                new CarroModel() {ID = 1, Nome = "Corsa", Placa = "ABC-1234", Ano = 1998},
                new CarroModel() {ID = 2, Nome = "Uno", Placa = "GHJ-6974", Ano = 1998},
                new CarroModel() {ID = 3, Nome = "Gol", Placa = "TYU-8547", Ano = 1998},
            };

        public IActionResult Index()
        {
            var model = new CarrosModel() { Carros = _Carros };
            return View(model);
        }

        public IActionResult Record(long id)
        {
            var carroAtual = _Carros.FirstOrDefault(carro => carro.ID == id);

            return View(carroAtual);
        }
    }
}
