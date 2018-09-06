namespace Site.Areas.shopadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using QuentinhaCarioca.Root;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    [Area("shopadmin")]
    public class CategoryController : Controller
    {
        private readonly string legalUserId;
        private readonly ICategoryService csrv;
        private List<Category> Categories;

        public CategoryController(ICategoryService cs)
        {
            this.legalUserId = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("LegalUser"));
            this.csrv = cs;
        }

        public IActionResult Index()
        {
            CategoryList();
            return View(Categories);
        }

        public IActionResult Create()
        {
            ViewBag.CategoriesListItems = CategoryListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category entity) 
        {
            csrv.Create(entity);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(string identifier)
        {
            var listItems   = CategoryListItems();
            var category    = csrv.Get(identifier);

            if (category.Parent != null)
            {
                listItems.ForEach(
                    (x) =>
                    {
                        if (x.Value == category.Parent.CategoryId.ToString())
                            x.Selected = true;
                    });
            }
            ViewBag.CategoriesListItems = listItems;
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category entity)
        {
            csrv.Update(entity);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> CategoryListItems()
        {
            CategoryList();
            var listItems = new List<SelectListItem> { new SelectListItem { Text = String.Empty, Value = String.Empty } };
            Categories.ForEach(
                (x) =>
                {
                    listItems.Add(new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
                });
            return listItems;
        }


        private List<Category> CategoryList()
        {
            Categories = csrv.GetAll(legalUserId);
            return Categories;
        }




    }
}