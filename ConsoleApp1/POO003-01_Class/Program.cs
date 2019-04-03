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
            MyClass myClass;
            //declaration
            myClass = new MyClass("Nguyen", "Viet", Convert.ToDateTime("2019-12-12"));
            //instantation par appeller à un constructor (déffault)
            Console.WriteLine(myClass);
            Console.WriteLine(myClass.GetMathPi(Math.PI));
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
}
