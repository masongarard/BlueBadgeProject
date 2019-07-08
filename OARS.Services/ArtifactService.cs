using OARS.Data;
using OARS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Services
{
    public class ArtifactService
    {
        private readonly Guid _archaeologistID;

        public ArtifactService(Guid archaeologistId)
        {
            _archaeologistID = archaeologistId;
        }

        public bool CreateArtifact(ArtifactCreate model)
        {
            var entity =
                new Artifact()
                {
                    ArtifactID=model.ArtifactID,
                    ArchaeologistID = _archaeologistID,
                    Description=model.Description,
                    Weight=model.Weight,
                    ElevationFound=model.ElevationFound,
                    ComparativeLayer=model.ComparativeLayer,
                    Latitude=model.Latitude,
                    Longitude=model.Longitude,
                    Material=model.Material,
                    ContextSoilType=model.ContextSoilType,
                    SoilColorMunsellValue=model.SoilColorMunsellValue,
                    DateTimeDiscovered=model.DateTimeDiscovered,
                    IsItDiagnostic=model.IsItDiagnostic,
                    ArchaeologicalSignificance=model.ArchaeologicalSignificance
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artifacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ArtifactListItem> GetArtifacts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artifacts
                        .Where(e => e.ArchaeologistID == _archaeologistID)
                        .Select(
                            e =>
                                new ArtifactListItem
                                {
                                    ArtifactID = e.ArtifactID,
                                    Description = e.Description,
                                    Weight = e.Weight,
                                    ElevationFound=e.ElevationFound,
                                    ComparativeLayer=e.ComparativeLayer,
                                    Latitude=e.Latitude,
                                    Longitude=e.Longitude,
                                    Material=e.Material,
                                    ContextSoilType= e.ContextSoilType,
                                    SoilColorMunsellValue=e.SoilColorMunsellValue,
                                    DateTimeDiscovered=e.DateTimeDiscovered,
                                    IsItDiagnostic=e.IsItDiagnostic,
                                    ArchaeologicalSignificance=e.ArchaeologicalSignificance,

                                }
                        );

                return query.ToArray();
            }
        }
    }
}
