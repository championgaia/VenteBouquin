using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Refac.Data;
using Refac.Logique;

namespace Refac.UnitTests
{
    [TestClass]
    public class PartiePenduTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestMotNull()
        {
            var p = new PartiePendu();

            var p1 = new Partie(null, 5);
            
            var partieData = p.VerifierLettre(p1, "T");
        }


        [TestMethod]
        public void TestPartieGagnee()
        {
            var p = new PartiePendu();

            var p1 = new Partie("TOTO", 5);

            var partieData = p.VerifierLettre(p1, "T");
            partieData = p.VerifierLettre(p1, "O");

            Debug.Assert(partieData.Resultat == "Partie Gagnée");
        }
        [TestMethod]
        public void TestPartiePerdue()
        {
            var p = new PartiePendu();

            var p1 = new Partie("TOTO", 5);

           var partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
      
            Debug.Assert(partieData.Resultat == "Partie Perdue");

        }
        [TestMethod]
        public void TestPatternEnCoursNonNull()
        {
            var p = new PartiePendu();

            var p1 = new Partie();

            var partieData = p.VerifierLettre(p1, "H");

            Debug.Assert(partieData.PatternEnCours != null);

        }
    }
}
