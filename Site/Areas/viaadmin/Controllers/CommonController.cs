namespace Site.Areas.viaadmin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using QuentinhaCarioca.Root;
    using System;
    using System.Collections.Generic;

    [Area("viaadmin")]
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ManageContactList([FromBody]Contact contact)
        {
            List<Contact> contactList;
            if (TempData["ContactList"] == null)
                contactList = new List<Contact>();
            else
                contactList = (List<Contact>)TempData["ContactList"];

            contact.ContactId = Guid.NewGuid();
            contactList.Add(contact);
            TempData["ContactList"] = contactList;

            return Json(contactList);
        }
    }
}