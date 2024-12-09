using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAplicacaoWeb.Models.Pessoas;

namespace MinhaPrimeiraAplicacaoWeb.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            var alunos = new List<PessoaModel>() {
                new PessoaModel() { ID = 1, Nome = "João", Situacao = "Em curso", Turma = "+Devs2Blu" },
                new PessoaModel() { ID = 2, Nome = "Maria", Situacao = "Em curso", Turma = "+Devs2Blu" },
                new PessoaModel() { ID = 3, Nome = "Ana", Situacao = "Em curso", Turma = "+Devs2Blu" },
                new PessoaModel() { ID = 4, Nome = "Bruno", Situacao = "Em curso", Turma = "+Devs2Blu" },
                new PessoaModel() { ID = 5, Nome = "Gabriel", Situacao = "Em curso", Turma = "+Devs2Blu" },
                new PessoaModel() { ID = 6, Nome = "Pedrinho", Situacao = "Concluído", Turma = "Jovem Programador" },
            };

            var model = new PessoasModel()
            {
                Pessoas = alunos,
            };

            return View(model);
        }
    }
}
