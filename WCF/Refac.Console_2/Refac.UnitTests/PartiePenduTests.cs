using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Refac.Logique;
using Refac.Data;

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

            var p1 = new Partie();
            p1.MotADeviner = null;
            p1.NbCoupsRestants = 5;
            p1.PatternEnCours = "____";

            var partieData = p.VerifierLettre(p1, "T");
        }


        [TestMethod]
        public void TestPartieGagnee()
        {
            var p = new PartiePendu();

            var p1 = new Partie();
            p1.MotADeviner = "TOTO";
            p1.NbCoupsRestants = 5;
            p1.PatternEnCours = "____";

            var partieData = p.VerifierLettre(p1, "T");
            partieData = p.VerifierLettre(p1, "O");

            Debug.Assert(partieData.Resultat == "Partie Gagnée");
        }
        [TestMethod]
        public void TestPartiePerdue()
        {
            var p = new PartiePendu();

            var p1 = new Partie();
            p1.MotADeviner = "TOTO";
            p1.NbCoupsRestants = 5;
            p1.PatternEnCours = "____";

           var partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
            partieData = p.VerifierLettre(p1, "H");
      
            Debug.Assert(partieData.Resultat == "Partie Perdue");

        }
    }
}
