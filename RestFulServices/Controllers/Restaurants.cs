namespace RestFulServices.Controllers
{
        using System;
        using Microsoft.AspNetCore.Mvc;
        using Services.Abstract;
        using Infrastructure.ResultHelper;
        

    [Route("restservices/restaurants")]
    public class Restaurants : Controller
    {       
        private int pageSize = 20;
        private ILegalUserService lsrv;
        public Restaurants(ILegalUserService ls)
        {
            this.lsrv = ls;
        }

        [HttpGet]
        public IActionResult Get(int? indexPage)
        {
            if(!indexPage.HasValue)
                indexPage = 1;
            var result = lsrv.GetAll(indexPage,pageSize);
            return StatusCode(InternalResultConst.Status200OK, result);
        }
    }
}
