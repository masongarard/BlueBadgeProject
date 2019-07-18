using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class SiteListItem
    {
        [Required]
        public int SiteID { get; set; }
        [Display(Name = "Modern Site Name")]
        public string ModernSiteName { get; set; }
        [Display(Name = "Ancient Site Name")]
        public string AncientSiteName { get; set; }

        [Required]
        public Guid ArchaeologistID { get; set; }

        public double Latitude { get; set; }
        
        public double Longitude { get; set; }


        //[Display(Name = "Eras Occupied")]
        //public string OccupiedEras { get; set; }
        //[Display(Name = "Identifiable Cultures Present")]
        //public string CulturesPresent { get; set; }
        //[Display(Name = "Past Site Directors")]
        //public string PastSiteDirectors { get; set; }
        [Display(Name = "Current Site Directors")]
        public string CurrentSiteDirectors { get; set; }
        [Display(Name = "Associated Universities")]
        public string AssociatedUniversities { get; set; }
    }
}
