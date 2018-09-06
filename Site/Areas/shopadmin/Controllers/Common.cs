namespace Site.Areas.shopadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using QuentinhaCarioca.Root;
    using Services.Abstract;
    using System;
    using System.Collections.Generic;

    public class Common
    {
        private readonly ICategoryService csrv;
        private string legalUserId = "3F848F47-D1B7-4AAD-BE15-7B43EF722616";
        private static List<Category> Categories;

        public Common(ICategoryService cs)
        {
            this.csrv = cs;
        }
    }
}
