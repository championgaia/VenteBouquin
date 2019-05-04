using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetPayeurTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetPayeurTestType()
        {
            var payeur = repo.GetPayeurDTORepoBol(1);
            Assert.AreEqual(typeof(PayeurDTO), payeur.GetType());
        }
        [TestMethod]
        public void GetPayeurTestNomPayeur()
        {
            var payeur = repo.GetPayeurDTORepoBol(1);
            Assert.AreEqual("NGUYEN", payeur.PersonneDto.NomDto);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPayeurTestVide()//a faire
        {
            var payeur = repo.GetPayeurDTORepoBol("");
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPayeurTestNull()//a faire
        {
            var payeur = repo.GetPayeurDTORepoBol(null);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPayeurTestNullException()//a faire
        {
            var payeur = repo.GetPayeurDTORepoBol(0);
        }
    }
}
