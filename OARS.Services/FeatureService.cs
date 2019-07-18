using OARS.Data;
using OARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Services
{
    public class FeatureService
    {
        private readonly Guid _archaeologistID;

        public FeatureService(Guid archaeologistId)
        {
            _archaeologistID = archaeologistId;
        }

        public bool CreateFeature(FeatureCreate model)
        {
            var entity =
                new Feature()
                {
                    FeatureID = model.FeatureID,
                    SiteID=model.SiteID,                   
                    ArchaeologistID = _archaeologistID,
                    Description = model.Description,
                    ElevationFound = model.ElevationFound,
                    ComparativeLayer = model.ComparativeLayer,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    ContextSoilType = model.ContextSoilType,
                    ContextSoilColorAsMunsellValue = model.ContextSoilColorAsMunsellValue,
                    FeatureSoilType = model.FeatureSoilType,
                    FeatureColorasMunsellValue = model.FeatureColorasMunsellValue,
                    DateTimeDiscovered = DateTime.Now,
                    IsItDiagnostic = model.IsItDiagnostic,
                    ArchaeologicalSignificance = model.ArchaeologicalSignificance
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Features.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FeatureListItem> GetFeatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Features
                        .Where(e => e.ArchaeologistID == _archaeologistID)
                        .Select(
                            e =>
                                new FeatureListItem
                                {
                                    FeatureID = e.FeatureID,
                                    SiteID=e.SiteID,
                                    ModernSiteName=e.Site.ModernSiteName,
                                    Description = e.Description,
                                    ElevationFound = e.ElevationFound,
                                }
                        );

                return query.ToArray();
            }
        }
        public FeatureDetail GetFeatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Features
                        .Single(e => e.FeatureID == id && e.ArchaeologistID == _archaeologistID);
                return
                    new FeatureDetail
                    {
                        FeatureID = entity.FeatureID,
                        SiteID = entity.SiteID,
                        ModernSiteName = entity.Site.ModernSiteName,
                        ArchaeologistID = _archaeologistID,
                        Description = entity.Description,
                        ElevationFound = entity.ElevationFound,
                        ComparativeLayer = entity.ComparativeLayer,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        ContextSoilType = entity.ContextSoilType,
                        ContextSoilColorAsMunsellValue = entity.ContextSoilColorAsMunsellValue,
                        FeatureSoilType = entity.FeatureSoilType,
                        FeatureColorasMunsellValue = entity.FeatureColorasMunsellValue,
                        DateTimeDiscovered = entity.DateTimeDiscovered,
                        IsItDiagnostic = entity.IsItDiagnostic,
                        ArchaeologicalSignificance = entity.ArchaeologicalSignificance
                    };
            }
        }
        public bool UpdateFeature(FeatureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Features
                        .Single(e => e.FeatureID == model.FeatureID && e.ArchaeologistID == _archaeologistID);
                entity.FeatureID = model.FeatureID;
                entity.SiteID = model.SiteID;
                entity.ArchaeologistID = _archaeologistID;
                entity.Description = model.Description;                
                entity.ElevationFound = model.ElevationFound;
                entity.ComparativeLayer = model.ComparativeLayer;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;               
                entity.ContextSoilType = model.ContextSoilType;
                entity.ContextSoilColorAsMunsellValue = model.ContextSoilColorAsMunsellValue;
                entity.FeatureSoilType = model.FeatureSoilType;
                entity.FeatureColorasMunsellValue = model.FeatureColorasMunsellValue;
                entity.DateTimeDiscovered = model.DateTimeDiscovered;
                entity.IsItDiagnostic = model.IsItDiagnostic;
                entity.ArchaeologicalSignificance = model.ArchaeologicalSignificance;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFeature(int featureID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Features
                        .Single(e => e.FeatureID == featureID && e.ArchaeologistID == _archaeologistID);

                ctx.Features.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public List<Site> GetSites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Sites.ToList();
            }
        }
    }
}
