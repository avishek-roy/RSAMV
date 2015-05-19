using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace RSAMV_Utility
{
    public class DropDown
    {
        /// <summary>
        /// Clients the type.
        /// </summary>
        /// <returns>Client Type list</returns>
        /// <CreatedBy>Avishek</CreatedBy>
        /// <CreatedDate>Mar-11-2015</CreatedDate>
        public static SelectList ClientType()
        {
            List<KeyValuePair<string, string>> statusKeyValuePairs = new List<KeyValuePair<string, string>>();
            statusKeyValuePairs.Add(new KeyValuePair<string, string>("RB", "RB"));
            statusKeyValuePairs.Add(new KeyValuePair<string, string>("NRB", "NRB"));
            statusKeyValuePairs.Add(new KeyValuePair<string, string>("FI", "FI"));
            statusKeyValuePairs.Add(new KeyValuePair<string, string>("ASI", "ASI"));
            statusKeyValuePairs.Add(new KeyValuePair<string, string>("MF", "MF"));
            SelectList statusSelectList = new SelectList(statusKeyValuePairs, "Key", "Value");
            return statusSelectList;
        }
    }
}