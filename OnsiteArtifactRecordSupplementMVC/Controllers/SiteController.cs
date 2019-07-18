using Microsoft.AspNet.Identity;
using OARS.Models;
using OARS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnsiteArtifactRecordSupplementMVC.Controllers
{
    [Authorize]
    public class SiteController : Controller
    {
        // GET: SiteIndex
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SiteService(userId);
            var model = service.GetSites();
            return View(model);
        }

        //GET: SiteCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: SiteCreate
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Create(SiteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSiteService();

            if (service.CreateSite(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSiteService();
            var model = svc.GetSiteById(id);

            return View(model);
        }

        //GET: SiteEdit
        public ActionResult Edit(int id)
        {
            var service = CreateSiteService();
            var detail = service.GetSiteById(id);
            var model =
                new SiteEdit
                {
                    SiteID = detail.SiteID,
                    ModernSiteName= detail.ModernSiteName,
                    AncientSiteName= detail.AncientSiteName,
                    Latitude= detail.Latitude,
                    Longitude= detail.Longitude,
                    CurrentSiteDirectors= detail.CurrentSiteDirectors,
                    AssociatedUniversities= detail.AssociatedUniversities,
                };
            return View(model);
        }

        //POST: SiteEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SiteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SiteID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSiteService();

            if (service.UpdateSite(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        //GET: SiteDelete
        public ActionResult Delete(int id)
        {
            var svc = CreateSiteService();
            var model = svc.GetSiteById(id);

            return View(model);
        }

        //POST: SiteDelete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSiteService();

            service.DeleteSite(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private SiteService CreateSiteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SiteService(userId);
            return service;
        }
    }

}