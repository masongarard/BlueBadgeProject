using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class ArtifactListItem
    {
        public int ArtifactID { get; set; }
        
        public string Description { get; set; }
        
        public double Weight { get; set; }
        //[Display(Name = "Elevation")]
        //public float ElevationFound { get; set; }
        //[Display(Name = "Relative Layer")]
        //public string ComparativeLayer { get; set; }

        //[Required]
        //public double Latitude { get; set; }
        //[Required]
        //public double Longitude { get; set; }
        //[Required]
        //public double Altitude { get; set; }


        public string Material { get; set; }
        //[Display(Name = "Contextual Soil Type")]
        //public string ContextSoilType { get; set; }
        //[Display(Name = "Munsell Value")]
        //public string SoilColorMunsellValue { get; set; }
        //[Display(Name = "Date & Time Of Discovery")]
        //public DateTime DateTimeDiscovered { get; set; }
        //[Display(Name ="Diagnostic? T/F")]
        //public bool IsItDiagnostic { get; set; }
        //[Display(Name = "Archaeological Significance")]
        //public string ArchaeologicalSignificance { get; set; }
    }
}
