using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetCommandeTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetCommandeTestType()
        {
            var commande = repo.GetCommandeDTORepoBol(1);
            Assert.AreEqual(typeof(CommandeDTO), commande.GetType());
        }
        [TestMethod]
        public void GetCommandeTestNomPayeur()
        {
            var commande = repo.GetCommandeDTORepoBol(1);
            Assert.AreEqual("NGUYEN", commande.LePayeurDto.PersonneDto.NomDto);
        }
        [TestMethod]
        public void GetCommandeTestPrix()
        {
            var commande = repo.GetCommandeDTORepoBol(1);
            Assert.AreEqual(10, commande.PrixTotalDto);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetCommandeTestNull()//a faire
        {
            var commande = repo.GetCommandeDTORepoBol(0);
        }
    }
}
