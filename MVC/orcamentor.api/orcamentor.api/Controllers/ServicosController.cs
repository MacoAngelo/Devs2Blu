using Microsoft.AspNetCore.Mvc;

namespace orcamentor.api.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
