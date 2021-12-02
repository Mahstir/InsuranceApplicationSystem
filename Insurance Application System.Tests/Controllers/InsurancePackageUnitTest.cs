using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Insurance_Application_System.Controllers.API;
using Insurance_Application_System.Controllers;

namespace Insurance_Application_System.Tests.Controllers
{
    [TestClass]
    public class InsurancePackages
    {
        [TestMethod]
        public void InsurancePackageIndexReturnsView()
        {
            var viewTest = new InsurancePackageController();

            var checkView = viewTest.Index();

            Assert.IsNotNull(checkView);
        }
    }
}
