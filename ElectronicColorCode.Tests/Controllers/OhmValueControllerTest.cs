using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicColorCode.Controllers;
using ElectronicColorCode.Interface;
using ElectronicColorCode.Models;
using System.Web.Mvc;
using ElectronicColorCode.Helper;

namespace ElectronicColorCode.Tests.Controllers
{
    /// <summary>
    /// Summary description for OhmValueControllerTest
    /// </summary>
    [TestClass]
    public class OhmValueControllerTest
    {
        IOhmValueCalculator _ohmValueCalculator = new OhmValueCalculator();
        OhmCalculator _ohmCalculator = new OhmCalculator();
        public OhmValueControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Index()
        {
            
            OhmValueController controller = new OhmValueController(_ohmValueCalculator, _ohmCalculator);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOhmValueWithInvalidString()
        {
            OhmValueController controller = new OhmValueController(_ohmValueCalculator, _ohmCalculator);
            JsonResult jsonResult = controller.GetOhmValue("A", "B", "C", "D");
            Assert.AreEqual(0, ((OhmCalculator)(jsonResult.Data)).FinalValue);
            Assert.AreEqual(null, ((OhmCalculator)(jsonResult.Data)).Tolerance);
        }

        [TestMethod]
        public void GetOhmValueWithValidString()
        {
            OhmValueController controller = new OhmValueController(_ohmValueCalculator, _ohmCalculator);
            JsonResult jsonResult = controller.GetOhmValue("1", "2", "10000000", "9");
            Assert.AreEqual(120000000, ((OhmCalculator)(jsonResult.Data)).FinalValue);
            Assert.AreEqual("ohms and 9% tolerance", ((OhmCalculator)(jsonResult.Data)).Tolerance);
        }

        [TestMethod]
        public void GetOhmValueWithAlphaNumeric()
        {
            OhmValueController controller = new OhmValueController(_ohmValueCalculator, _ohmCalculator);
            JsonResult jsonResult = controller.GetOhmValue("1A", "2B", "10C", "9Z");
            Assert.AreEqual(0, ((OhmCalculator)(jsonResult.Data)).FinalValue);
            Assert.AreEqual(null, ((OhmCalculator)(jsonResult.Data)).Tolerance);
        }

        [TestMethod]
        public void GetOhmValueWithDecimalBandDValue()
        {
            OhmValueController controller = new OhmValueController(_ohmValueCalculator, _ohmCalculator);
            JsonResult jsonResult = controller.GetOhmValue("1", "2", "10", "0.005");
            Assert.AreEqual(120, ((OhmCalculator)(jsonResult.Data)).FinalValue);
            Assert.AreEqual("ohms and 0.005% tolerance", ((OhmCalculator)(jsonResult.Data)).Tolerance);
        }
    }
}
