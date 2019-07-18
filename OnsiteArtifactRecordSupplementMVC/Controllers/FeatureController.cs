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
    public class FeatureController : Controller
    {
        // GET: FeatureIndex
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            var model = service.GetFeatures();
            return View(model);
        }

        //GET: FeatureCreate
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var FeatureService = new FeatureService(userId);

            ViewBag.SiteID = new SelectList(FeatureService.GetSites(), "SiteID", "ModernSiteName");
            return View();
        }
        //POST: FeatureCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeatureCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateFeatureService();

            if (service.CreateFeature(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Note could not be created.");
            ViewBag.SiteID = new SelectList(service.GetSites(), "SiteID", "ModernSiteName", model.SiteID);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFeatureService();
            var model = svc.GetFeatureById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFeatureService();
            var detail = service.GetFeatureById(id);
            var model =
                new FeatureEdit
                {
                    FeatureID = detail.FeatureID,
                    SiteID = detail.SiteID,
                    ModernSiteName = detail.ModernSiteName,
                    Description = detail.Description,                    
                    ElevationFound = detail.ElevationFound,
                    ComparativeLayer = detail.ComparativeLayer,
                    Latitude = detail.Latitude,
                    Longitude = detail.Longitude,                    
                    ContextSoilType = detail.ContextSoilType,
                    ContextSoilColorAsMunsellValue= detail.ContextSoilColorAsMunsellValue,
                    FeatureSoilType= detail.FeatureSoilType,
                    FeatureColorasMunsellValue= detail.FeatureColorasMunsellValue,
                    DateTimeDiscovered = detail.DateTimeDiscovered,
                    IsItDiagnostic = detail.IsItDiagnostic,
                    ArchaeologicalSignificance = detail.ArchaeologicalSignificance
                };
            ViewBag.SiteID = new SelectList(service.GetSites(), "SiteID", "ModernSiteName", model.SiteID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FeatureEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FeatureID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFeatureService();

            if (service.UpdateFeature(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateFeatureService();
            var model = svc.GetFeatureById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFeature(int id)
        {
            var service = CreateFeatureService();

            service.DeleteFeature(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private FeatureService CreateFeatureService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FeatureService(userId);
            return service;
        }
    }
}