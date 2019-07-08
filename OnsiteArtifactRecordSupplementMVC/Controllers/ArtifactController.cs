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
            return View();
        }

        //POST: Create Artifact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtifactCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateArtifactService();

            if (service.CreateArtifact(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);            
        }

        private ArtifactService CreateArtifactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtifactService(userId);
            return service;
        }
    }
}