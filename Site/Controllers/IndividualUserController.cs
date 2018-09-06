namespace Site.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using QuentinhaCarioca.Root;
    using Services.Abstract;

    public class IndividualUserController : Controller
    {
        IIndividualUserService usr;
        ICommonServices csr;
        private static List<SelectListItem> stateList;

        public IndividualUserController(IIndividualUserService us, ICommonServices cs)
        {
            this.usr = us;
            this.csr = cs;
        }


        public IActionResult Index(int? pageIndex, int? pageSize)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (!pageSize.HasValue)
                pageSize = 20;

            var customers = usr.GetAll(pageIndex.Value, pageSize.Value);
            return View(customers);
        }

        public IActionResult Create()
        {
            GetStates();
            ViewBag.StateList = stateList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer entity)
        {
            usr.Create(entity);
            return View();
        }

        public IActionResult Edit(string identifier)
        {
            GetStates();
            var customer    = usr.Get(identifier);
            int statedId    = customer.User.Addresses.First().City.StateId;
            int cityId      = customer.User.Addresses.First().City.CityId;
            stateList.ForEach((x) =>
            {
                if (x.Value == statedId.ToString())
                    x.Selected = true;
            });

            List<SelectListItem> citiesList = new List<SelectListItem> { new SelectListItem { Text = String.Empty, Value = String.Empty } };
            GetCities(statedId).ForEach((x) =>{citiesList.Add(new SelectListItem { Text = x.Name, Value = x.CityId.ToString(), Selected = x.CityId == cityId });});
            ViewBag.CitiesList  = citiesList;
            ViewBag.StateList   = stateList;
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer entity)
        {
            usr.Edit(entity);
            return RedirectToAction("Index");
        }

        private List<City> GetCities(int stateId)
        {
            return csr.GetCities(stateId);
        }
        private void GetStates()
        {
            if (stateList != null && stateList.Count > 0)
                return;
            stateList = new List<SelectListItem> { new SelectListItem { Text = String.Empty, Value = String.Empty } };
            csr.GetStates().ForEach((x) =>{stateList.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });});
        }

    }
}