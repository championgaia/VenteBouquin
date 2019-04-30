using Refac.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refac.Logique
{
    public class PartiePendu
    {
        public Partie VerifierLettre(Partie p, string lettre)
        {
            if (p.MotADeviner.Contains(lettre))
            {
                // detecter les occurences de la lettre et mettre à jour le Pattern
                var positionsTrouvées = new List<int>();
                for (int i = 0; i < p.MotADeviner.Length; i++)
                {
                    if (p.MotADeviner[i] == lettre[0])
                        positionsTrouvées.Add(i);
                }
                //modifier le pattern 
                char[] patternencours = p.PatternEnCours.ToCharArray();
                foreach (var positionIndex in positionsTrouvées)
                {
                    patternencours[positionIndex] = p.MotADeviner[positionIndex];
                }
                p.PatternEnCours = new string(patternencours);
            }
            else
            {
                // lettre pas dans le mot
                p.NbCoupsRestants--;
            }
            if (p.PatternEnCours == p.MotADeviner)
                p.Resultat = "Partie Gagnée";

            if (p.NbCoupsRestants <= 0)
                p.Resultat = "Partie Perdue";
            return p;
        }
    }
}
