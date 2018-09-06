namespace Site.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Abstract;
    using Services.Concrete;

    public class CommonController : Controller
    {

        [HttpPost]
        public JsonResult GetCities([FromBody] string identifier)
        {
            ICommonServices commonSrv = new CommonServices();
            var result = commonSrv.GetCities(int.Parse(identifier));
            return Json(result);
        }
    }
}