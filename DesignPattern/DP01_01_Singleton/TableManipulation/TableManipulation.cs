using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP01_01_Singleton.DesignPattern
{
    class TableManipulation
    {
        List<Table> MesTables;
        //List<TestTable> MesTest;
        public TableManipulation()
        {
            MesTables = new List<Table>
            {
                new TableCarre("Red", "Bois", 4),
                new TableRonde("Green", "Acier", 5.6),
                new TableRectanculaire("Yellow","Plastique", 4, 5)
            };
            foreach (var item in MesTables)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine(item.CalculatePerimettre());
                Console.WriteLine(item.CalculateSurface());
            }
            //foreach (var item in MesTest)
            //{
            //    Console.WriteLine(item.ToString());
            //    Console.WriteLine(item.CalculatePerimettre());
            //    Console.WriteLine(item.CalculateSurface());
            //}
        }
    }
    #region Table
    public abstract class Table
    {
        protected string Couleur { get; set; }
        protected string Materiau { get; set; }
        public override string ToString()
        {
            return string.Format("la table a la couleur {0} de {1} ", Couleur, Materiau);
        }
        public abstract double CalculatePerimettre();
        public abstract double CalculateSurface();
        #region Table
        public Table() {  }
        #endregion
        #region GetCouleur
        public string GetCouleur()
        {
            return Couleur;
        }
        #endregion
        #region GetMateriau
        public string GetMateriau()
        {
            return Materiau;
        }
        #endregion
        #region Table
        public Table(string couleur, string materiau)
        {
            Couleur = couleur;
            Materiau = materiau;
        }  
        #endregion
    }
    #endregion
    #region TestTable
    public abstract class TestTable:Table
    {
        protected double PrixParMetre;
        public abstract double CalculatePrix();
    }
    #endregion
    #region TableCarre
    class TableCarre : Table
    {
        double Cote;
        #region construteur
        public TableCarre(){}
        #endregion
        #region construteur
        public TableCarre(string couleur, string materiau, double cote) : base(couleur, materiau)
        {
            Cote = cote;
        }
        #endregion
        public override double CalculatePerimettre()
        {
            return Cote * 4;
        }
        public override double CalculateSurface()
        {
            return Cote*Cote;
        }

        
    }
    #endregion
    #region TableRonde
    class TableRonde : Table
    {
        double Diametre;
        public TableRonde(string couleur, string materiau, double diametre) : base(couleur, materiau)
        {
            Diametre = diametre;
        }
        public override double CalculatePerimettre()
        {
            return 2 * Math.PI * Diametre;
        }
        public override double CalculateSurface()
        {
            return Math.PI*Diametre*Diametre;
        }
        
    }
    #endregion
    #region TableTriangle
    class TableTriangle : Table
    {
        double Cote;
        public TableTriangle(string couleur, string materiau, double cote) : base(couleur, materiau)
        {
            Cote = cote;
        }
        public override double CalculatePerimettre()
        {
            return 3 * Cote;
        }
        public override double CalculateSurface()
        {
            return 1/2*Cote*Cote*Math.Sin(Math.PI/3);
        }
    }
    #endregion
    #region TableRectanculaire
    class TableRectanculaire : Table
    {
        double CoteLong;
        double CoteHaut;
        public TableRectanculaire(string couleur, string materiau, double coteLong, double coteHaut) : base(couleur, materiau)
        {
            CoteHaut = coteHaut;
            CoteLong = coteLong;
        }
        public override double CalculatePerimettre()
        {
            return 2 * CoteLong + 2 * CoteHaut;
        }
        public override double CalculateSurface()
        {
            return CoteLong * CoteHaut;
        }
    }
    #endregion

}
