using Microsoft.AspNetCore.Mvc;
using TechReciclyingAlpha.Filters;

namespace TechReciclyingAlpha.Controllers
{
    [PaginaParaUsuarioLogado]  

    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
