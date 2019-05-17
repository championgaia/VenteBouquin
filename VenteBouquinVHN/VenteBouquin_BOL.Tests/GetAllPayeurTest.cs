using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetAllPayeurTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetAllPayeurTestType()
        {
            var lesPayeur = repo.GetAllPayeurDTORepoData();
            Assert.AreEqual(typeof(List<PayeurDTO>), lesPayeur.GetType());
        }
        [TestMethod]
        public void GetAllPayeurTestNomPayeur()
        {
            var lesPayeur = repo.GetAllPayeurDTORepoData();
            Assert.AreEqual("NGUYEN", lesPayeur.FirstOrDefault().PersonneDto.NomDto);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAllPayeurTestVide()//a faire
        {
            var lesPayeur = repo.GetAllPayeurDTORepoData();
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAllPayeurTestNull()//a faire
        {
            var lesPayeur = repo.GetAllPayeurDTORepoData();
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAllPayeurTestNullException()//a faire
        {
            var lesPayeur = repo.GetAllPayeurDTORepoData();
        }
    }
}
