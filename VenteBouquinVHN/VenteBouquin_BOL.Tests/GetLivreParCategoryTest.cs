using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetLivreParCategoryTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetLivreParCategoryTestType()
        {
            var liste = repo.GetLivreParCategoryDTORepoBol(2);
            Assert.AreEqual(typeof(List<LivreDTO>), liste.GetType());
        }
        [TestMethod]
        public void GetLivreParCategoryTestVide()
        {
            var liste = repo.GetLivreParCategoryDTORepoBol(0);
            Assert.AreEqual(0, liste.Count);
        }
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLivreParCategoryTestNull()//a faire
        {
            var liste = repo.GetLivreParCategoryDTORepoBol(0);
        }
    }
}
