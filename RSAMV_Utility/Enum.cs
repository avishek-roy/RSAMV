using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSAMV_Utility
{
    public static class Enum
    {

        public static decimal ToDecimal(this Enum.ClientType status)
        {
            object val = Convert.ChangeType(status, status.GetTypeCode());
            return val.ToDecimal();
        }

        public enum ClientType
        {
            RB = 1,
            NRB = 2,
            FI = 3,
            MF = 4,
            ASI = 5
        }
    }
}