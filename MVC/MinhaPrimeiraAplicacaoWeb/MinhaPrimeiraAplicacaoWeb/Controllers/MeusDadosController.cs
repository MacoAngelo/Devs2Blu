using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraAplicacaoWeb.Controllers
{
    public class MeusDadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
