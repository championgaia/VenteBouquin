using JeuDeMotBOL.ClassBol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotBOL
{
    public class RepoBol
    {
        private JeuDeMotBol jeu;
        public void InitPlay()
        {
            jeu = new JeuDeMotBol();
        }
        public string DisplayWord()
        {
            return jeu.LeMotADisplay;
        }
        public string DisplayGoal()
        {
            return jeu.MonMot;
        }
        public string MakeChoise(char maLettre)
        {
            return jeu.MakeChoise(maLettre);
        }
        public object TestChoise(char maLettre)
        {
            return new {Id = maLettre, Libelle = jeu.MakeChoise(maLettre) };
        }
    }
}
