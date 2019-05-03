using VenteBouquin_BOL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        public RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetLivreCategoryDTOsRepoBolTest()
        {
            var liste = repo.GetLivreCategoryDTOsRepoBol();
            Assert.AreEqual(typeof(List<LivreCategoryDTO>), liste.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLivreCategoryDTOsRepoBolTest1()//a faire
        {
            var liste = repo.GetLivreCategoryDTOsRepoBol();
        }

        [TestMethod]
        public void GetLivreCategoryDTOsRepoBolTest2()
        {

        }
    }
}
