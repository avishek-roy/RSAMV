using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSAMV_Utility
{
    public static class Extenstion
    {
        public static int ToInt32(this object obj)
        {
            int result = 0;
            if (Int32.TryParse(obj.ToString(), out result))
                return result;
            else return 0;
        }

        public static decimal ToDecimal(this object obj)
        {
            decimal result = 0;
            if (decimal.TryParse(obj.ToString(), out result))
                return result;
            else return 0;
        }
    }
}