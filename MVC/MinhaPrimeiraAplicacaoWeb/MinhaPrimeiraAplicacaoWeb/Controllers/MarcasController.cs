//using Microsoft.AspNetCore.Mvc;
//using MinhaPrimeiraAplicacao.Utils.Entidades;
//using MinhaPrimeiraAplicacaoWeb.Models.Carros;
//using MinhaPrimeiraAplicacaoWeb.Models.Marcas;

//namespace MinhaPrimeiraAplicacaoWeb.Controllers
//{
//    public class MarcasController : Controller
//    {
//        public IActionResult Index()
//        {
//            var model = new MarcasModel();
//            var carros = Carro.GetAll();

//            //Avançada
//            model.Marcas = carros.Select(carroEntidade => new MarcaModel(carroEntidade)).ToList();

//            return View(model);
//        }

//        public IActionResult Record(long? id)
//        {
//            var model = new MarcaModel();

//            if (id.HasValue)
//            {
//                model = new MarcaModel(Carro.Get(id.Value));
//            }

//            return View(model);
//        }

//        [HttpPost]
//        public IActionResult Record(MarcaModel model, string type)
//        {
//            Carro carro = model.GetEntidade();
//            if (type == "save")
//            {
//                if (carro.ID > 0)
//                {
//                    carro.Update();
//                }
//                else
//                {
//                    carro.Create();
//                }
//            }
//            else if (type == "delete")
//            {
//                carro.Delete();
//            }
//            else
//            {
//                return BadRequest("Requisição inválida!");
//            }

//            return RedirectToAction("Index");
//        }
//    }
//}