using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.SAI.Activities.Helper
{
    public static class StringExtensions
    {

        public static string posttleft(this string str,string val )
        {
            return str.Substring(str.IndexOf(val) + val.Length);
        }
    }
}
