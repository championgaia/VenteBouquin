using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeuDeMotBOL;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        RepoBol repo = new RepoBol();
        [TestMethod]
        public void MakeChoiseTest()
        {
            char maLettre = '0';
            Assert.AreEqual(repo.MakeChoise(maLettre), repo.DisplayWord());
        }
    }
}
