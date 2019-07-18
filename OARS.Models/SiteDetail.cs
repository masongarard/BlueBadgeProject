using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class SiteDetail
    {
        [Required]        
        public int SiteID { get; set; }
        [Required]
        public Guid ArchaeologistID { get; set; }
        [Display(Name = "Modern Site Name")]
        public string ModernSiteName { get; set; }
        [Display(Name = "Ancient Site Name (If known)")]
        public string AncientSiteName { get; set; }

        

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }


        [Required]
        [Display(Name = "Occupation Timeline")]
        public string OccupiedEras { get; set; }
        [Required]
        [Display(Name = "Visible Cultures")]
        public string CulturesPresent { get; set; }

        [Display(Name = "Past Site Directors")]
        public string PastSiteDirectors { get; set; }
        [Required]
        [Display(Name = "Current Site Directors")]
        public string CurrentSiteDirectors { get; set; }
        [Required]
        [Display(Name = "Associated Universities")]
        public string AssociatedUniversities { get; set; }
    }
}
