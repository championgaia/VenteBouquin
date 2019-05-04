using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenteBouquin_DTO.class_dto;

namespace VenteBouquin_BOL.Tests
{
    [TestClass]
    public class GetLivreParCodeISBNTest
    {
        private RepoBOL repo = new RepoBOL();
        [TestMethod]
        public void GetLivreParCodeISBNTestType()
        {
            var livre = repo.GetLivreParCodeISBNDTORepoBol("9782075094504");
            Assert.AreEqual(typeof(LivreDTO), livre.GetType());
        }
        [TestMethod]
        public void GetLivreParCodeISBNTestNomLivre()
        {
            var livre = repo.GetLivreParCodeISBNDTORepoBol("9782075094504");
            Assert.AreEqual("Harry Potter à l école des sorciers", livre.NomLivreDto);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLivreParCodeISBNTestVide()//a faire
        {
            var livre = repo.GetLivreParCodeISBNDTORepoBol("");
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetLivreParCodeISBNTestNullException()//a faire
        {
            var livre = repo.GetLivreParCodeISBNDTORepoBol(null);
        }
    }
}
