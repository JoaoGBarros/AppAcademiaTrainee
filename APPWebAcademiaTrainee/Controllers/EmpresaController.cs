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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CompanyCode, CompanyName, CompanyFantasyName, CompanyCNPJ")] EmpresaModel empresaModel)
        {
            Console.Write(empresaModel);
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
