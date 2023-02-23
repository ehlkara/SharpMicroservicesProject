using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SharpCourse.Web.Models.Catalogs
{
	public class FeatureViewModel
	{
        [Display(Name = "Course Duration")]
        [Required]
        public int Duration { get; set; }
    }
}

