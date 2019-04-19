using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFrameworkCodeFirst
{

    class Carre : Rectangle
    {
        internal Carre(int largeur, int longueur) : base(largeur, longueur)
        {
            Longueur = largeur;
            Largeur = largeur;
        }



    }



    class Rectangle
    {
        private int _largeur;

        public int Largeur
        {
            get { return _largeur; }
            set { _largeur = value; }
        }
        private int _longueur;

        public int Longueur
        {
            get { return _longueur; }
            set { _longueur = value; }
        }

        public Rectangle(int largeur, int longueur)
        {
            Largeur = largeur;
            Longueur = longueur;
        }
        public int CalculPérimetre()
        {
            return (_longueur + _largeur) * 2;
        }


    }
}
