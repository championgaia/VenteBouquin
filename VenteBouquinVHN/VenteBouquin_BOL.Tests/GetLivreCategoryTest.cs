using VenteBouquin_BOL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetLivreCategoryTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetLivreCategoryTestType()
        {
            var liste = repo.GetLivreCategoryDTOsRepoBol();
            Assert.AreEqual(typeof(List<LivreCategoryDTO>), liste.GetType());
        }
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLivreCategoryTestNull()//a faire
        {
            var liste = repo.GetLivreCategoryDTOsRepoBol();
        }
    }
}
