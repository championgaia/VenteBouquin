using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi03_01_NorthWind;
using WebApi03_01_NorthWind.Controllers;

namespace WebApi03_01_NorthWind.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disposer
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Affirmer
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
