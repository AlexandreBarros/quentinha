namespace Site.Areas.shopadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using QuentinhaCarioca.Root;
    using Services.Abstract;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [Area("shopadmin")]

    public class ItemController : Controller
    {
        private string legalUserId = "3F848F47-D1B7-4AAD-BE15-7B43EF722616";
        private readonly IItemService isrv;
        private readonly ICommonServices csrv;
        private readonly ICategoryService ctSrv;


        private List<Category> Categories;
        public ItemController(IItemService isrv, ICommonServices csrv, ICategoryService ctSrv)
        {
            this.ctSrv = ctSrv;
            this.csrv = csrv;
            this.isrv = isrv;
        }

        public IActionResult Index()
        {
            var itemList = isrv.GetItems(legalUserId);
            return View(itemList);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryItems = CategoryListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item entity)
        {
            isrv.Create(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string identifier)
        {
            var item        = isrv.GetItem(identifier);
            var categories  = CategoryListItems();
            foreach (var option in categories)
            {
                if (String.IsNullOrWhiteSpace(option.Value)) continue;
                if (item.CategoriesItems.FirstOrDefault(x => x.CategoryId == Guid.Parse(option.Value)) != null)
                    option.Selected = true;
            }
            ViewBag.CategoryItems = categories;
            return View(item);
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

        private void CategoryList()
        {
            Categories = ctSrv.GetAll(legalUserId);
        }


    }
}