using ElectronicColorCode.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicColorCode.Helper
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>int</returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int calValue = 0;
            calValue = Convert.ToInt32(bandAColor + bandBColor);
            return calValue;
        }
    }
}