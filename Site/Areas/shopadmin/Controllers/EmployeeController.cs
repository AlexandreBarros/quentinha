namespace Site.Areas.shopadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using QuentinhaCarioca.DTO;
    using QuentinhaCarioca.Root.ViewModel;
    using Services.Abstract;
    using Newtonsoft.Json;
    using QuentinhaCarioca.Root;

    [Area("shopadmin")]
    public class EmployeeController : Controller
    {
        private string legalUserId ;
        private readonly IEmployeeService epSrv;
        private readonly ICommonServices commonSrv;
        public EmployeeController(ICommonServices commonSrv, IEmployeeService isrv)
        {
            
            this.epSrv          = isrv;
            this.commonSrv      = commonSrv;
        }
        public IActionResult Index(int? pageIndex, int? pageSize)
        {
            if(!pageIndex.HasValue || (pageIndex.HasValue && pageIndex.Value == -1) || (pageIndex.HasValue && pageIndex.Value == 0))
                pageIndex = 1;
            if (!pageSize.HasValue)
                pageSize = 20;

            this.legalUserId = HttpContext.Session.GetString("LegalUser");
            ViewData["PageIndex"] = pageIndex;
            var result = epSrv.GetAll(pageIndex, pageSize.Value, legalUserId);
            return View(result);
        }

        public IActionResult Create()
        {
            this.legalUserId = HttpContext.Session.GetString("LegalUser");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee user)
        {
            epSrv.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string identifier)
        {
            var result = epSrv.Get(identifier);
            var resultResponse = new EmployeeRequest
            {
                EmployeeId = result.EmployeeId
                , Contacts = result.User.Contacts
                , CreationDate = result.User.CreationDate
                , DetachmentDate = result.User.DetachmentDate
                , FirstName = result.User.FirstName
                , LastName = result.User.LastName
                , LegalUserId = result.LegalUser.LegalUserId
                , UserName = result.User.UserName
            };
            return View(resultResponse);
        }

        [HttpPost]
        public void Delete([FromBody] string identifier)
        {
            epSrv.Delete(identifier);
        }

        [HttpPost]
        public void Reactivate([FromBody] string identifier)
        {
            epSrv.Reactivate(identifier);
        }




    }
}