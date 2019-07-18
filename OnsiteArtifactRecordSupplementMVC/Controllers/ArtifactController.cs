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
    public class ArtifactController : Controller
    {
        // GET: Artifact Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            var model = service.GetArtifacts();
            return View(model);
        }

        //GET: Create Artifact
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ArtifactService = new ArtifactService(userId);

            ViewBag.SiteID = new SelectList(ArtifactService.GetSites(), "SiteID", "ModernSiteName");
            return View();
        }

        //POST: Create Artifact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtifactCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateArtifactService();

            if (service.CreateArtifact(model))
            {
                TempData["SaveResult"] = "Your Artifact was Logged.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Artifact could not be created.");
            ViewBag.SiteID = new SelectList(service.GetSites(), "SiteID", "ModernSiteName", model.SiteID);
            return View(model);            
        }
        
        public ActionResult Details(int id)
        {
            var svc = CreateArtifactService();
            var model = svc.GetArtifactById(id);

            return View(model);
        }
        //GET: Edit Artifact
        public ActionResult Edit(int id)
        {
            var service = CreateArtifactService();
            var detail = service.GetArtifactById(id);
            var model =
                new ArtifactEdit
                {
                    ArtifactID = detail.ArtifactID,
                    SiteID = detail.SiteID,
                    ModernSiteName = detail.ModernSiteName,
                    Description = detail.Description,
                    Weight = detail.Weight,
                    ElevationFound = detail.ElevationFound,
                    ComparativeLayer = detail.ComparativeLayer,
                    Latitude = detail.Latitude,
                    Longitude = detail.Longitude,
                    Material = detail.Material,
                    ContextSoilType = detail.ContextSoilType,
                    SoilColorMunsellValue = detail.SoilColorMunsellValue,
                    DateTimeDiscovered = detail.DateTimeDiscovered,
                    IsItDiagnostic = detail.IsItDiagnostic,
                    ArchaeologicalSignificance = detail.ArchaeologicalSignificance
                };
            ViewBag.SiteID = new SelectList(service.GetSites(), "SiteID", "ModernSiteName", model.SiteID);
            return View(model);
        }
        //POST: Edit Artifact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArtifactEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtifactID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtifactService();

            if (service.UpdateArtifact(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View();
        }
        //GET: Delete Artifact
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateArtifactService();
            var model = svc.GetArtifactById(id);

            return View(model);
        }

        //POST: Delete Artifact
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArtifactService();

            service.DeleteArtifact(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        private ArtifactService CreateArtifactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            return service;
        }
    }
}