using OARS.Data;
using OARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Services
{
    public class SiteService
    {
        private readonly Guid _archaeologistID;

        public SiteService(Guid archaeologistID)
        {
            _archaeologistID = archaeologistID;
        }
       
        public bool CreateSite(SiteCreate model)
        {
            var entity =
                new Site()
                {
                    SiteID=model.SiteID,
                    ModernSiteName = model.ModernSiteName,
                    AncientSiteName = model.AncientSiteName,
                    ArchaeologistID=_archaeologistID,
                    Latitude = model.Latitude,
                    Longitude=model.Longitude,
                    OccupiedEras=model.OccupiedEras,
                    CulturesPresent=model.CulturesPresent,
                    PastSiteDirectors=model.PastSiteDirectors,
                    CurrentSiteDirectors=model.CurrentSiteDirectors,
                    AssociatedUniversities=model.AssociatedUniversities
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SiteListItem> GetSites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sites
                        .Where(e => e.ArchaeologistID == _archaeologistID)
                        .Select(
                            e =>
                                new SiteListItem
                                {
                                    SiteID=e.SiteID,
                                    ModernSiteName = e.ModernSiteName,
                                    AncientSiteName = e.AncientSiteName,
                                    ArchaeologistID=e.ArchaeologistID,
                                    Latitude = e.Latitude,
                                    Longitude = e.Longitude,
                                    //OccupiedEras = e.OccupiedEras,
                                    //CulturesPresent = e.CulturesPresent,
                                    //PastSiteDirectors = e.PastSiteDirectors,
                                    CurrentSiteDirectors = e.CurrentSiteDirectors,
                                    AssociatedUniversities = e.AssociatedUniversities
                                }
                        );

                return query.ToArray();
            }
        }

        public SiteDetail GetSiteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sites
                        .Single(e => e.SiteID == id && e.ArchaeologistID == _archaeologistID);
                return
                    new SiteDetail
                    {
                        SiteID=entity.SiteID,
                        ArchaeologistID=_archaeologistID,
                        ModernSiteName= entity.ModernSiteName,
                        AncientSiteName = entity.AncientSiteName,
                        Latitude = entity.Latitude,
                        Longitude= entity.Longitude,
                        OccupiedEras= entity.OccupiedEras,
                        CulturesPresent= entity.CulturesPresent,
                        PastSiteDirectors= entity.PastSiteDirectors,
                        CurrentSiteDirectors= entity.CurrentSiteDirectors,
                        AssociatedUniversities= entity.AssociatedUniversities,
                    };
            }
        }

        public bool UpdateSite(SiteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sites
                        .Single(e => e.SiteID == model.SiteID && e.ArchaeologistID == _archaeologistID);

                entity.SiteID = model.SiteID;
                entity.ArchaeologistID = _archaeologistID;
                entity.ModernSiteName = model.ModernSiteName;
                entity.AncientSiteName = model.AncientSiteName;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;
                entity.OccupiedEras = model.OccupiedEras;
                entity.CulturesPresent = model.CulturesPresent;
                entity.PastSiteDirectors = model.PastSiteDirectors;
                entity.CurrentSiteDirectors = model.CurrentSiteDirectors;




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSite(int siteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sites
                        .Single(e => e.SiteID == siteId && e.ArchaeologistID == _archaeologistID);

                ctx.Sites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
