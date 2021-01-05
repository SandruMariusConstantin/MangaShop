using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MangaShop.Models;

namespace MangaShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult New()
        {
            ContactInfo contact = new ContactInfo();
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            return View(contact);
        }

        [HttpPost]
        public ActionResult New(ContactInfo contactRequest)
        {
            ViewBag.RegionList = GetAllRegions();
            ViewBag.GenderList = GetAllGenderTypes();
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactsInfo.Add(contactRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }
                return View(contactRequest);
            }
            catch (Exception)
            {
                return View(contactRequest);
            }
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllRegions()
        {
            var selectList = new List<SelectListItem>();
            foreach (var region in db.Regions.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = region.RegionId.ToString(),
                    Text = region.Name
                });
            }
            return selectList;
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllGenderTypes()
        {
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem
            {
                Value = Gender.Male.ToString(),
                Text = "Male"
            });

            selectList.Add(new SelectListItem
            {
                Value = Gender.Female.ToString(),
                Text = "Female"
            });

            return selectList;
        }
    }
}