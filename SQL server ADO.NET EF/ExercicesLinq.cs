using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    public class ExercicesLinq
    {
        public void Exercice1_NombrePositifs()
        {
            int[] n1 = {
                1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14
            };
            //Trouver les nombres positifs dans la liste

            List<int> results = new List<int>();
            //  results = ;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice2_JoursSemaine()
        {
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            //Afficher les jours de la semaine en minuscule

            List<string> results = new List<string>();
            //  results = ;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice3_Superieur80()
        {
            List<int> templist = new List<int>();
            templist.Add(55);
            templist.Add(200);
            templist.Add(740);
            templist.Add(76);
            templist.Add(230);
            templist.Add(482);
            templist.Add(95);

            //n'afficher que les nombres > 80

            List<int> results = new List<int>();
            //  results = ;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice4_average()
        {
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            //calculer la valeur moyenne de ce tableau

            double result = 0;

            // result = ???;

            Console.WriteLine(result);
            Console.ReadKey();
        }
        public void Exercice5_TriMultiple()
        {
            string[] cities =
             {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            //trier les villes par nombre de caracteres, puis ( pour les villes de meme taille)  par leur nom dans l'ordre alphabétique inversé.

            List<int> results = new List<int>();
            //  results = ;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice6_parse()
        {
            string[] numbersAsString = new string[] { "3", "1", "2", "4" };

            //Convertir ce tableau de string en list d'entier

            List<int> results = new List<int>();
            //  results = ;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public void ExerciceDur_SFindUppercase()
        {
            var testString = "Ceci Est uNe StrIng Un Peu bIZarre";

            // n'afficher que les lettres en majuscules
            // en sortie ou bien une liste de lettres ou une string avec uniquement ces lettres en majuscules.

            List<string> results = new List<string>();
            string resultat;
            //  results = ;
            // ou
            // resultat = ;
        }
        public void ExerciceDur_Frequence()
        {
            var testString = "Ceci Est uNe StrIng Un Peu bIZarre";

            //afficher chaque lettre avec le nombre de fois qu'elle apparait dans le chaine de caracteres
            //ex : C : 2, E:5
           

            List<string> results = new List<string>();
            string resultat;
            //  results = ;
            // ou
            // resultat = ;
        }
    }
}
