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
            results = n1.Where(n=>n > 0).ToList();

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
            results = dayWeek.Select(d=>d.ToLower()).ToList();

            ////// autre solution avec foreach
            ////foreach(var item2 in dayWeek)
            ////{
            ////    results.Add(item2.ToLower());
            ////}

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
            results = templist.Where(n=>n>80).ToList();

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

            double result = arr1.Average();

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

            List<string> results = new List<string>();
            results = cities.OrderBy(c=>c.Length).ThenByDescending(c=>c).ToList();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public void Exercice7_top()
        {
            int[] arr1 = new int[] { 5, 9, 12, 2, 3, 7, 5, 61, 7, 3, 7, 6, 8, 5, 44, 9, 6, 12 };

            //afficher les 4 plus grands nombres (distincts) de la liste



        }



        public void Exercice6_parse()
        {
            string[] numbersAsString = new string[] { "3", "1", "2", "4",null };

            //Convertir ce tableau de string en list d'entier

            List<int> results = new List<int>();
           results =  numbersAsString.Where(x=>x != null).Select(n=>Int32.Parse(n)).ToList();

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public void ExerciceDur_SFindUppercase()
        {
            var testString = "Ceci EST uNe STRING Un Peu bIZarre";

            // n'afficher que les mots avec toutes les lettres en majuscules
            List<string> results = new List<string>();
            results = testString.Split(' ').Where(m => m == m.ToUpper()).ToList();
        }
        public void ExerciceDur_Frequence()
        {
            var testString = "Ceci Est uNe StrIng Un Peu bIZarre";

            //afficher chaque lettre avec le nombre de fois qu'elle apparait dans le chaine de caracteres
            //ex : C : 2, E:5

            var res2 = testString.ToCharArray()
                .GroupBy(g => g)
                .Select(g => new
                {
                   Lettre= g.Key,
                   Nombre =  g.Count()
                }
                );
            foreach (var item in res2)
            {
                Console.WriteLine(item.Lettre + " " + item.Nombre);
            }

            //var results = (from x in testString.ToCharArray()
            //               group x by x into y
            //               select y).ToList();
            //foreach (var item in results)
            //{
            //    Console.WriteLine(item.Key + " " + item.Count());
            //}
            Console.ReadKey();




        }
    }
}
