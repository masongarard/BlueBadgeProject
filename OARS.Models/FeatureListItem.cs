using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class FeatureListItem
    {
        public int FeatureID { get; set; }
        public int SiteID { get; set; }
        public string ModernSiteName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Elevation")]
        public float ElevationFound { get; set; }
        //[Display(Name = "Relative Layer")]
        //public string ComparativeLayer { get; set; }

        
        //public double Latitude { get; set; }
        
        //public double Longitude { get; set; }


                
        //[Display(Name = "Contextual Soil Type")]
        //public string ContextSoilType { get; set; }
        //[Display(Name = "Contextual Soil Munsell Value")]
        //public string ContextSoilColorAsMunsellValue { get; set; }
        //[Display(Name = "Feature Soil Type")]
        //public string FeatureSoilType { get; set; }
        //[Display(Name = "Feature Soil Munsell Value")]
        //public string FeatureColorasMunsellValue { get; set; }
        //[Display(Name = "Date & Time of Discovery")]
        //public DateTime DateTimeDiscovered { get; set; }
        //[Display(Name = "Diagnostic? T/F")]
        //public bool IsItDiagnostic { get; set; }
        //[Display(Name = "Archaeological Significance")]
        //public string ArchaeologicalSignificance { get; set; }

    }
}
