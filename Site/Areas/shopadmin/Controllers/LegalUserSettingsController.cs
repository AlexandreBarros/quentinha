namespace Site.Areas.shopadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using QuentinhaCarioca.Root;
    using Services.Abstract;
    using Newtonsoft.Json;

    [Area("shopadmin")]
    public class LegalUserSettingsController : Controller
    {
        private readonly ILegalUserService lsrv;
        private string legalUserId ;

        public LegalUserSettingsController(ILegalUserService lsr)
        {
            this.lsrv = lsr;
        }

        public IActionResult Index()
        {
            var settings = lsrv.GetLegalUserSettings(legalUserId);
            return View(settings);
        }

        public IActionResult Create()
        {
            legalUserId = HttpContext.Session.GetString("LegalUser");
            return View();
        }

        [HttpPost]
        public IActionResult Create(LegalUserSettings entity)
        {
            lsrv.CreateLegalSettings(entity);
            return RedirectToAction("Create", "Employee");

        }

        public IActionResult Edit(string identifier)
        {
            var settings = lsrv.GetLegalUserSettings(legalUserId);
            return View(settings);
        }

        [HttpPost]
        public IActionResult Edit(LegalUserSettings settings)
        {
            lsrv.EditLegalSettings(settings);
            return RedirectToAction("Index");
        }
    }
}