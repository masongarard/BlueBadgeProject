using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class FeatureCreate
    {
        public int FeatureID { get; set; }
        [Required]
        public int SiteID { get; set; }
        public string ModernSiteName { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Distance From Surface")]
        public float ElevationFound { get; set; }
        [Required]
        [Display(Name = "Relative Layer")]
        public string ComparativeLayer { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }


        [Required]
        [Display(Name = "Contextual Soil Type")]
        public string ContextSoilType { get; set; }
        [Required]
        [Display(Name = "Contextual Munsell Value")]
        public string ContextSoilColorAsMunsellValue { get; set; }
        [Required]
        [Display(Name = "Feature Soil Type")]
        public string FeatureSoilType { get; set; }
        [Required]
        [Display(Name = "Feature Munsell Value")]
        public string FeatureColorasMunsellValue { get; set; }
        [Required]
        [Display(Name = "Time Discovered")]
        public DateTime DateTimeDiscovered { get; set; }
        [Required]
        [Display(Name = "Diagnostic? T/F")]
        public bool IsItDiagnostic { get; set; }
        [Required]
        [Display(Name = "Archaeological Significance")]
        public string ArchaeologicalSignificance { get; set; }
    }
}
