using System;
using System.Device.Location;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OARS.Data
{
    public class Site
    {
        [Key]
        [Required]
        public string ModernSiteName { get; set; }        
        public string AncientSiteName { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        

        [Required]
        public string OccupiedEras { get; set; }
        [Required]
        public string CulturesPresent { get; set; }
        
        public string PastSiteDirectors { get; set; }
        [Required]
        public string CurrentSiteDirectors { get; set; }
        [Required]
        public string AssociatedUniversities { get; set; }
    }
}
