using Microsoft.AspNetCore.Mvc;

namespace PsicoApp.Controllers
{
    public class GaleriaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
