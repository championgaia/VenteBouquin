using ConsoleApp1.Mes_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /*1)  exercices
        Créer une classe personne avec les méthodes suivantes et attributs suivants :
            A) Nom, prenom, adresse (string)    et  emploi(boolean)
            B)  créer une classe dérivée  stagiaire  avec les méthodes supplémentaires durée_stage de type date
                et une methode étudier qui prends en parametre la duréé et la matiere étudiéé
            C) Instancier  4 stagiaires de votre choix
            D) créer une méthode dans la classe dérivée permettant d’afficher les matières et  les durées associées

     * */
        static void Main(string[] args)
        {
            Stagiaire personne1 = new Stagiaire("Doe", "John", "2 avenue Charles de Gaule",
                true , Convert.ToDateTime("2019/01/01"), Convert.ToDateTime("2019/10/01"), "CDA");
            Stagiaire personne2 = new Stagiaire("Doe", "Jane", "2 avenue Jourdan",
                true, Convert.ToDateTime("2019/02/01"), Convert.ToDateTime("2019/08/01"), "PhP");
            Stagiaire personne3 = new Stagiaire("Adam", "John", "2 avenue du Champs",
                true, Convert.ToDateTime("2019/03/01"), Convert.ToDateTime("2019/10/01"), "CDA");
            Stagiaire personne4 = new Stagiaire("Doe", "John", "2 avenue Napoleon",
                true, Convert.ToDateTime("2019/04/01"), Convert.ToDateTime("2019/09/01"), "CDA");
            personne1.Afficher();
            Console.Read();
        }
    }
}
