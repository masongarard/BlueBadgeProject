using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class ArtifactCreate
    {
        [Required]
        public int ArtifactID { get; set; }
        public int SiteID { get; set; }
        public string ModernSiteName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [Display(Name = "Distance From Surface (Note: Positive Values Only Please)")]
        public float ElevationFound { get; set; }
        [Display(Name = "Relative Layer")]
        public string ComparativeLayer { get; set; }

        //AAAAAAAAAAAAHHHHHHHHHHHHHH
        //[Required]
        //public GeoCoordinate GeoCoordinate
        //{
        //    get
        //    {
        //        return GeoCoordinate;
        //    }
        //    set
        //    {

        //        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

        //        // Do not suppress prompt, and wait 1000 milliseconds to start.
        //        watcher.Start();

        //        GeoCoordinate coord = watcher.Position.Location;
        //        watcher.Stop();
        //        if (coord.IsUnknown != true)
        //        {
        //            GeoCoordinate = coord;
        //        }
        //        else
        //        {
        //            GeoCoordinate = null;
        //        }
        //    }
        //}

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }        


        [Required]
        public string Material { get; set; }
        [Required]
        [Display(Name = "Contextual Soil Type")]
        public string ContextSoilType { get; set; }
        [Required]
        [Display(Name = "Munsell Value")]
        public string SoilColorMunsellValue { get; set; }
        [Required]
        [Display(Name = "Date & Time Of Discovery")]
        public DateTime DateTimeDiscovered { get; set; }
        [Required]
        [Display(Name = "Diagnostic? T/F")]
        public bool IsItDiagnostic { get; set; }
        [Required]
        [Display(Name = "Archaeological Significance")]
        public string ArchaeologicalSignificance { get; set; }
    }
}
