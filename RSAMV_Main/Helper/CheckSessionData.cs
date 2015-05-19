using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BR_Main.Helper
{
    public class CheckSessionData
    {
        public CheckSessionData(long id, string name)
            {
                Id = id;
                Name = name;
            }
            public long Id { get; set; }
            public string Name { get; set; }

            public static Dictionary<int, CheckSessionData> GetSessionValues()
            {
                Dictionary<int, CheckSessionData> sessionData = new Dictionary<int, CheckSessionData>();
                if (HttpContext.Current.Session["LoginCompany"] == null)
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(0, "CompanyId");
                    sessionData.Add(1, aCheckSessionData);
                }
                else
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(long.Parse(HttpContext.Current.Session["LoginCompany"].ToString()), "CompanyId");
                    sessionData.Add(1, aCheckSessionData);
                }
                if (HttpContext.Current.Session["LoginLocation"] == null)
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(0, "LocationId");
                    sessionData.Add(2, aCheckSessionData);
                }
                else
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(long.Parse(HttpContext.Current.Session["LoginLocation"].ToString()), "LocationId");
                    sessionData.Add(2, aCheckSessionData);
                }
                if (HttpContext.Current.Session["LoginUser"] == null)
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(0, "UserName");
                    sessionData.Add(3, aCheckSessionData);
                }
                else
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(long.Parse(HttpContext.Current.Session["LoginUser"].ToString()), HttpContext.Current.Session["LoginUserName"].ToString());
                    sessionData.Add(3, aCheckSessionData);
                }

                if (HttpContext.Current.Session["LoginDepartment"] == null)
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(0, "DepartmentId");
                    sessionData.Add(4, aCheckSessionData);
                }
                else
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(long.Parse(HttpContext.Current.Session["LoginDepartment"].ToString()), "DepartmentId");
                    sessionData.Add(4, aCheckSessionData);
                }

                if (HttpContext.Current.Session["LoginLevel"] == null)
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(0, "LevelId");
                    sessionData.Add(5, aCheckSessionData);
                }
                else
                {
                    CheckSessionData aCheckSessionData = new CheckSessionData(long.Parse(HttpContext.Current.Session["LoginLevel"].ToString()), "LevelId");
                    sessionData.Add(5, aCheckSessionData);
                }
               return sessionData;
            }
       
    }
}