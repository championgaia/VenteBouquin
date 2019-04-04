using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO003_01_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyClass
            //declaration
            MyClass myClass; int a;
            //instation
            myClass = new MyClass();
            //donneur une valeur pour la class
            myClass.Nom = "Nguyen"; a = 2;
            myClass.Prenom = "Viet";
            myClass.DateNaissance = Convert.ToDateTime("2019-12-12");
            //version 2
            myClass = new MyClass("Nguyen", "Viet", Convert.ToDateTime("2019-12-12"));
            //instantation par appeller à un constructor (déffault)
            Console.WriteLine(myClass);
            Console.WriteLine(myClass.GetMathPi(Math.PI));
            Console.WriteLine(a);
            #endregion
            #region voiture1
            Voiture voiture1 = new Voiture
            {
                Couleur = "Red",
                Marque = "BMW",
                NumeroImmatriculation = Guid.NewGuid().ToString(),
                Vitesse = 0
            };
            Voiture voiture2 = new Voiture
            {
                Couleur = "Blue",
                Marque = "Langbohiri",
                NumeroImmatriculation = Guid.NewGuid().ToString(),
                Vitesse = 10
            };
            voiture1.Demarrer();
            voiture1.Accelerer(10);
            Console.WriteLine(voiture1);
            #endregion
            #region Moto
            Moto myMoto = new Moto
            {
                Place = 12
            };

            #endregion
            #region Voitures
            Voitures lesVoitures = new Voitures(voiture1, voiture2);
            foreach (var item in lesVoitures.ListeVoiture)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.Read();
        }
    }
    public class MyClass
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        #region constructeur par deffaut
        public MyClass()
        {

        }
        #endregion
        #region constructeur MyClass
        public MyClass(string nom, string prenom, DateTime myDate)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = myDate;
        }
        #endregion
        #region Math.pi*7
        public double GetMathPi(double pi)
        {
            return pi * 7;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format($"Nom {Nom} Prenom {Prenom} a né le {DateNaissance}");
        }
        #endregion
    }
    public class Voiture
    {
        public string NumeroImmatriculation { get; set; }
        public string Couleur { get; set; }
        public string Marque { get; set; }
        public int Vitesse { get; set; }
        
        #region constructeur par déffault
        public Voiture()
        {

        }
        #endregion
        #region constructeur 3 params
        public Voiture(string numero, string couleur, string marque)
        {
            NumeroImmatriculation = numero;
            Couleur = couleur;
            Marque = marque;
        }
        #endregion
        #region Demarrer
        public void Demarrer()
        {
            Vitesse = 0;
            Console.WriteLine("Ca demarre");
        }
        #endregion
        #region Rouler
        public void Rouler()
        {
            Console.WriteLine("Ca roule");
        }
        #endregion
        #region Freiner
        public void Freiner()
        {
            Vitesse = 0;
            Console.WriteLine("Ca stop");
        }
        #endregion
        #region Accelerer
        public void Accelerer(int par)
        {
            Vitesse += par;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format("Voiture {0} \n de marque de marque {1} avec la couleur {2} \n a rouler avec la vitesse de {3}", NumeroImmatriculation, Marque, Couleur, Vitesse ); 
        }
        #endregion
    }
    public sealed class Cascade : Voiture
    {
        public string Puissance { get; set; }
        #region Cascade
        public Cascade()
        {

        }
        #endregion
        #region Cascade
        public Cascade(string numero, string couleur, string marque, string puissance) : base(numero, couleur, marque)
        {
            Puissance = puissance;
        }
        #endregion
    }
    public class Moto
    {
        private int _place;
        public int Place
        {
            get { return _place; }
            set { _place = value; }
        }
        private string Caption { get; set; }
    }
    public class Voitures
    {
        public List<Voiture> ListeVoiture { get; set; }
        public Voitures()
        {

        }
        public Voitures(Voiture v1, Voiture v2)
        {
            ListeVoiture = new List<Voiture>() { v1, v2};
        }
    }
}
