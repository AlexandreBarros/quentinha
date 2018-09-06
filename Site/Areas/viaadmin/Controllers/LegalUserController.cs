namespace Site.Areas.viaadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using QuentinhaCarioca.Root;
    using Services.Abstract;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    [Area("viaadmin")]
    public class LegalUserController : Controller
    {
        private readonly ILegalUserService legalSrv;
        private readonly ICommonServices commonSrv;
        private static List<SelectListItem> stateList;

        public LegalUserController(ILegalUserService lSrv
            , ICommonServices cSrv)
        {
            legalSrv = lSrv;
            commonSrv = cSrv;
        }

        public IActionResult Index(int? pageIndex, int? pageSize)
        {
            if (!pageIndex.HasValue || (pageIndex.HasValue && pageIndex.Value == -1) || (pageIndex.HasValue && pageIndex.Value == 0))
                pageIndex = 1;
            if (!pageSize.HasValue)
                pageSize = 20;

            ViewData["PageIndex"] = pageIndex;
            var resultList = legalSrv.GetAll(pageIndex, pageSize.Value);
            return View(resultList);
        }


        #region LEGALUSER

        public IActionResult Create()
        {
            var classes = legalSrv.RestaurantClassList();
            List<SelectListItem> listItems = new List<SelectListItem>();
            classes.ForEach((x) => { listItems.Add(new SelectListItem { Text = x.Name, Value = x.RestaurantClassesId.ToString() }); });
            ViewBag.ClassesList = listItems;
            SetViewData();
            return View();
        }

        [HttpPost]
        public IActionResult Create(LegalUser entity)
        {
            try
            {
                var rsult = legalSrv.Create(entity);
                HttpContext.Session.SetString("LegalUser", rsult.LegalUserId.ToString());
                return RedirectToAction("Create", "LegalUserSettings", new { area = "shopadmin" });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Edit(string identifier)
        {
            var legalUser = legalSrv.Get(identifier);
            SetViewData();
            return View(legalUser);
        }

        [HttpPost]
        public IActionResult Edit(LegalUser legalUser)
        {
            legalSrv.Edit(legalUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(string identifier)
        {
            legalSrv.Remove(identifier);
            return RedirectToAction("Index");
        }

        #endregion

        private void SetViewData()
        {
            GetStates();
            ViewBag.StateList = stateList;
        }

        private List<SelectListItem> GetStates()
        {
            if (stateList != null && stateList.Count > 0)
                return stateList;

            stateList   = new List<SelectListItem> { new SelectListItem { Text = string.Empty, Value = string.Empty } };
            var states  = commonSrv.GetStates();
            states.ForEach(x =>{stateList.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });});
            return stateList;
        }

    }
}