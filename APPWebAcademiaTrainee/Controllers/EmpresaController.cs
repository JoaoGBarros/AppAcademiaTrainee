using Microsoft.AspNetCore.Mvc;
using APPWebAcademiaTrainee.Models;
using System.Diagnostics;

namespace APPWebAcademiaTrainee.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
