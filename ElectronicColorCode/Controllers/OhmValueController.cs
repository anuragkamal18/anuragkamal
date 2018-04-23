using ElectronicColorCode.Interface;
using ElectronicColorCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ElectronicColorCode.Controllers
{
    public class OhmValueController : Controller
    {
        public readonly IOhmValueCalculator _ohmValueCalculator = null;
        public readonly OhmCalculator _ohmCalculator = null;

        /// <summary>
        /// OhmValueController constructor
        /// </summary>
        /// <param name="ohmValueCalculator"></param>
        /// <param name="ohmCalculator"></param>
        public OhmValueController(IOhmValueCalculator ohmValueCalculator, OhmCalculator ohmCalculator)
        {
            _ohmValueCalculator = ohmValueCalculator;
            _ohmCalculator = ohmCalculator;
        }
        
        /// <summary>
        /// To load the index view
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors and the tolerance value band.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>Json Result</returns>
        public JsonResult GetOhmValue(string bandAValue, string bandBValue, string bandCValue, string bandDValue)
        {
            Regex regex = new Regex(@"^[0-9]\d*(\.\d+)?$");
            if (regex.IsMatch(bandAValue) && regex.IsMatch(bandBValue) && regex.IsMatch(bandCValue) && regex.IsMatch(bandDValue))
            {
                int retVal = 0;
                //_ohmCalculator.FinalValue = _ohmValueCalculator.CalculateOhmValue(bandAValue, bandBValue, bandCValue, bandDValue);
                retVal = _ohmValueCalculator.CalculateOhmValue(bandAValue, bandBValue, bandCValue, bandDValue);
                _ohmCalculator.FinalValue = retVal * Convert.ToDecimal(bandCValue);
                _ohmCalculator.Tolerance = "ohms and " + bandDValue + "% tolerance";
            }
            return Json(_ohmCalculator, JsonRequestBehavior.AllowGet);
        }
    }
}