using System;
using System.Device.Location;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OARS.Data
{
    public class Feature
    {
        [Key]
        public int FeatureID { get; set; }

        [ForeignKey(nameof(Site))]
        public int SiteID { get; set; }

        public virtual Site Site { get; set; }

        [Required]
        public Guid ArchaeologistID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float ElevationFound { get; set; }
        [Required]
        public string ComparativeLayer { get; set; }
        
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        
                
        [Required]
        public string ContextSoilType { get; set; }
        [Required]
        public string ContextSoilColorAsMunsellValue { get; set; }
        [Required]
        public string FeatureSoilType { get; set; }
        [Required]
        public string FeatureColorasMunsellValue { get; set; }
        [Required]
        public DateTime DateTimeDiscovered { get; set; }
        [Required]
        public bool IsItDiagnostic { get; set; }
        [Required]
        public string ArchaeologicalSignificance { get; set; }
    }
}
