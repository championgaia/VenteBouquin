using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refac.Logique;
using System.Diagnostics;
using Refac.Data;

namespace RefacTest
{
    [TestClass]
    public class PartiePenduTest
    {
        PartiePendu PartieM = new PartiePendu();
        Partie P1 = new Partie();
        [TestMethod]
        public void TestPartieGagne()
        {
            P1.MotADeviner = "ABCDEFGHKL";
            P1.NbCoupsRestants = 12;
            P1.PatternEnCours = "**********";
            var partieData = PartieM.VerifierLettre(P1, P1.MotADeviner[0].ToString());
                //new Partie();
            for (int i = 1; i < P1.MotADeviner.Length; i++)
            {
                partieData = PartieM.VerifierLettre(P1, P1.MotADeviner[i].ToString());
            }
            Debug.Assert(partieData.Resultat == "Partie Gagnée");
        }
        [TestMethod]
        public void TestPartiePerdu()
        {
            P1.MotADeviner = "ABCDEFGHKL";
            P1.NbCoupsRestants = 12;
            P1.PatternEnCours = "**********";
            var partieData = PartieM.VerifierLettre(P1, "M");
            for (int i = 0; i < 12; i++)
            {
                partieData = PartieM.VerifierLettre(P1, "M");
            }
            Debug.Assert(partieData.Resultat == "Partie Perdue");
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPartieMotNullException()
        {
            P1.MotADeviner = null;
            P1.NbCoupsRestants = 12;
            P1.PatternEnCours = "**********";
            var partieData2 = PartieM.VerifierLettre(P1, "E");
        }
        [TestMethod]
        public void TestPartieMotNull()
        {
            P1.MotADeviner = "";
            //P1.MotADeviner = null;
            P1.NbCoupsRestants = 12;
            P1.PatternEnCours = "**********";
            Debug.Assert(string.IsNullOrEmpty(P1.MotADeviner)==true);
        }
        [TestMethod]
        public void TestPartieLettreNotAlphaNumerique()
        {
            P1.MotADeviner = "ABCDEFGHKL";
            P1.NbCoupsRestants = 12;
            P1.PatternEnCours = "**********";
            var partieData1 = PartieM.VerifierLettre(P1, "Enter");
            var partieData2 = PartieM.VerifierLettre(P1, "E");
            Debug.Assert(partieData1.PatternEnCours == partieData2.PatternEnCours);
        }
    }
}
