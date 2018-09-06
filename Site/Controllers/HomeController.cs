namespace Site.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Abstract;
    using Site.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        ILegalUserService lSrv;

        public HomeController(ILegalUserService lSrv)
        {
            this.lSrv = lSrv;

        }

        public IActionResult Authenticate() => View();


        public IActionResult Index(int? pageSize, int? pageIndex)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (!pageSize.HasValue )
                pageSize = 20;

            var shops = lSrv.GetAll(pageIndex, pageSize.Value);
            return View(shops);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
