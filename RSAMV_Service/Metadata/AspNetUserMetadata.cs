using RSAMV_Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSAMV_Service.Metadata
{
    [MetadataType(typeof(ProjectCategory))]
    public partial class ProjectCategory
    {
        public class ProjectCategoryMetadata
        {
            [Display(Name = "Project Category Name")]
            public string ProjectName { get; set; }

            [Display(Name = "Project Category Code")]
            [Required(ErrorMessage = "Select an category code")]
            public string ProjectCode { get; set; }
        }
    }
}