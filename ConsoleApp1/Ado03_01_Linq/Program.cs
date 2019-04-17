using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado03_01_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Manipulation manip = new Manipulation();
            int[] myTable = { 1, 2, 3, 4, 1, 1, 7, 1, 9, 222, 666 };
            string myString = "THIS IS MY string";
            foreach (var item in manip.GetNumberAndSquare(myTable))
            {
                //Console.WriteLine("Number = " +item.Key + "SqrNumber = " +item.Value);
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetNumberAndFrequency(myTable))
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetDayOfWeek())
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetNumberAndFrequencyAndMultiple(myTable))
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetNumberTopNth(myTable, 5))
            {
                Console.WriteLine(item);
            }
            foreach (var item in manip.GetUpperWordInString(myString))
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
    public class Manipulation
    {
        // Write a program in C# Sharp to shows how the three parts of a query operation execute
        #region GetPaireNumber
        public int[] GetPaireNumber(int[] myTable)
        {
            if (myTable.Length != 0)
            {
                return myTable.Select(c => c).Where(c => c % 2 == 0).ToArray();
            }
            return null;
        }
        #endregion
        // Write a program in C# Sharp to find the +ve numbers from a list of numbers using 
        //two where conditions in LINQ Query
        #region GetNumberInRange
        public int[] GetNumberInRange(int[] myTable, int startNumber, int endNumber)
        {
            if (myTable.Length != 0)
            {
                return myTable.Select(c => c).Where(c => c >= startNumber && c <= endNumber).ToArray();
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to find the number of an array and the square of each number
        #region GetNumberAndSquare
        public Dictionary<int, int> GetNumberAndSquare(int[] myTable)
        {
            if (myTable.Length != 0)
            {
                //return myTable.Select(c => new Result { Key = c, Value = c*c}).ToList();
                return myTable.Select(c =>  new  { Key = c, Value = c * c }).Distinct().ToDictionary(a => a.Key, a => a.Value);
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to display the number and frequency of number from giving array
        #region GetNumberAndFrequency
        public Dictionary<int, int> GetNumberAndFrequency(int[] myTable)
        {
            if (myTable.Length != 0)
            {
                Dictionary<int, int> myDic = new Dictionary<int, int>();
                var temp = myTable.Distinct().ToArray();
                foreach (var item in temp)
                {
                    var count = myTable.Select(c => c).Where(c => c == item).Count();
                    myDic.Add(item, count);
                }
                return myDic;
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to display the characters and frequency of character from giving string
        #region GetCharacterAndFrequency
        public Dictionary<char, int> GetCharacterAndFrequency(string myString)
        {
            if (myString.Length != 0)
            {
                Dictionary<char, int> myDic = new Dictionary<char, int>();
                var temp = myString.Distinct().ToArray();
                foreach (var item in temp)
                {
                    var count = myString.Select(c => c).Where(c => c == item).Count();
                    myDic.Add(item, count);
                }
                //return myString.GroupBy(p => p)
                //    .Select(p => new { Count = p.Count(), Char = p.Key })
                //    .GroupBy(p => p.Count, p => p.Char);
                return myDic;
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to display the name of the days of a week.
        #region GetDayOfWeek
        public List<string> GetDayOfWeek()
        {
            List<string> myList = new List<string>();
            List<DateTime> mesDate = new List<DateTime>();
            var tempStart = DateTime.Now;
            var tempEnd = DateTime.Now.AddMonths(1);
            for (DateTime time = tempStart; time < tempEnd; time = time.AddDays(1))
            {
                mesDate.Add(time);

            }
            return mesDate.Select(c => c.DayOfWeek.ToString()).Distinct().ToList();
        }
        #endregion
        //Write a program in C# Sharp to display numbers, multiplication of number with frequency and 
        //frequency of a number of giving array
        #region GetNumberAndFrequencyAndMultiple
        public List<object> GetNumberAndFrequencyAndMultiple(int[] myTable)
        {
            if (myTable.Length != 0)
            {
                List<object> myList = new List<object>();
                var temp = myTable.Distinct().ToArray();
                foreach (var item in temp)
                {
                    var count = myTable.Select(c => c).Where(c => c == item).Count();
                    var tempV = item * count;
                    myList.Add(new {item, count, tempV });
                }
                return myList;
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to display the top n-th records
        #region GetNumberTopNth
        public int[] GetNumberTopNth(int[] myTable, int topNumber)
        {
            if (myTable.Length != 0)
            {
                return myTable.Select(c => c).OrderByDescending(c => c).Take(topNumber).ToArray();
            }
            return null;
        }
        #endregion
        //Write a program in C# Sharp to find the uppercase words in a string
        #region GetUpperWordInString
        public List<string> GetUpperWordInString(string myWord)
        {
            List<string> myResult = new List<string>();
            if (myWord.Length != 0)
            {
                //string[] tableWord = myWord.Split(' ');
                //foreach (var item in tableWord)
                //{
                //    if (item == item.ToUpper())
                //        myResult.Add(item);
                //}
                myResult = myWord
                    .Split(' ')
                    .Select(c => c)
                    .Where(c => c == c.ToUpper())
                    .ToList();
                return myResult;
            }
            return null;
        }
        #endregion
    }
}
