using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Extensions
{
    public static class RateExtension
    {
        public static decimal Percent(this decimal value, decimal percentage)
        {
            return value * (percentage / 100);
        }
    }
}
