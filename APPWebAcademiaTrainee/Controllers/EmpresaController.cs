using Microsoft.AspNetCore.Mvc;
using APPWebAcademiaTrainee.Models;
using System.Diagnostics;

namespace APPWebAcademiaTrainee.Controllers
{
    public class EmpresaController : Controller
    {
        
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
