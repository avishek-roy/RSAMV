using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using RSAMV_Service.Interfaces;
using RSAMV_Service.Factories;
using RSAMV_Service.Models;


namespace RSAMV_Main.Controllers
{
    public class ProjectCategoryController : Controller
    {

        //private IGenericFactory<ProjectCategory> factory;

        private IGenericFactory<ProjectCategory> factory;    

        public JsonResult GetLastContact()
        {
            List<ProjectCategory> c = factory.FindBy(x => x.ProjectCategoryId == 1).ToList();
            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
