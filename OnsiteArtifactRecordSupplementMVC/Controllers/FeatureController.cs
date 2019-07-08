using OARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnsiteArtifactRecordSupplementMVC.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        public ActionResult Index()
        {
            var model = new FeatureListItem[0];
            return View(model);
        }
    }
}