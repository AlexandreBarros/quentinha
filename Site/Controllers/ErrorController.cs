namespace Site.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuentinhaCarioca.Root.ViewModel;
    using System.Diagnostics;
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}