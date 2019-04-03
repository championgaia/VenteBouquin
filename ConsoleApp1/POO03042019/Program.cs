using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO03042019
{
    class Program
    {
        static void Main(string[] args)
        {
            var manip = new Manipulation();
            Console.WriteLine(manip.Addition(12, 24));
            Console.WriteLine(manip.Division(12, 24));
            foreach (var item in manip.GetList())
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetListString())
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetHastSet())
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetDictionary())
            {
                Console.WriteLine(item.Key + item.Value);
            }
            Console.Read();
        }

    }
    public class Manipulation
    {
        public double Addition(double param1, double param2)
        {
            return param1 + param2;
        }
        public double Division(double param1, double param2)
        {
            return param1 / param2;
        }
        public List<int> GetList()
        {
            List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            return myList;
        }
        public List<string> GetListString()
        {
            List<string> myList = new List<string>()
                { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            myList.Sort();
            myList.Reverse();
            return myList;
        }
        public HashSet<int> GetHastSet()
        {
            HashSet<int> myHashSet = new HashSet<int>() { 12, 23, 55, 54 };
            return myHashSet;
        }
        public Dictionary<int, string> GetDictionary()
        {
            Dictionary<int, string> myDic = new Dictionary<int, string>()
            { { 1, "Neuer" }, {12, "Messi" }, {23, "Figo" }, {55, "Zidane" }, {54, "Boccar" } };
            return myDic;
        }
    }
}

