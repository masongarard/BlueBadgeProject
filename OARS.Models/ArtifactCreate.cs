﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OARS.Models
{
    public class ArtifactCreate
    {
        [Required]
        public int ArtifactID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [Display(Name = "Elevation")]
        public float ElevationFound { get; set; }
        [Display(Name = "Relative Layer")]
        public string ComparativeLayer { get; set; }

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
