using OARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnsiteArtifactRecordSupplementMVC.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            var model = new SiteListItem[0];
            return View(model);
        }
    }
}