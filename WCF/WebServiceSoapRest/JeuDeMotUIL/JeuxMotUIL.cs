using JeuDeMotBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeMotUIL
{
    internal class JeuxMotUIL
    {
        public int LimitMax { get; set; }
        public int NombrePlay { get; set; }
        RepoBol repo = new RepoBol();
        public JeuxMotUIL()
        {
            LimitMax = new Random().Next(5, 10);
            NombrePlay = 0;
        }
        public void Play()
        {
            repo.InitPlay();
            bool continueJeu = false;
            while (!continueJeu)
            {
                Console.WriteLine("This is my word");
                Console.WriteLine(repo.DisplayWord());
                Console.WriteLine("Enter your choise");
                char saisie = Console.ReadLine().ToCharArray().FirstOrDefault();
                Console.WriteLine(repo.TestChoise(saisie).ToString());
                if (NombrePlay>LimitMax)
                {
                    Console.WriteLine("perdu");
                    break;
                }
                else
                {
                    if (
                        repo.DisplayGoal() == MakeChoise(saisie))
                    {
                        Console.WriteLine("gagné");
                        break;
                    }
                    else
                    {
                        NombrePlay++;
                    }
                }
            }
        }
        public string MakeChoise(char maLettre)
        {
            return repo.MakeChoise(maLettre);
        }
        public object TestChoise(char maLettre)
        {
            return repo.TestChoise(maLettre);
        }
    }
}
