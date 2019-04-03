using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerObject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            Test mytest = new Test();
            List<string> testList = new List<string>() { "1", "2", "3", "4", "5" };
            mytest.SetMyList(testList);
            #endregion
            #region MyRegion
            Test newTest = new Test();
            List<string> newList = new List<string>() { "6", "7", "8", "9" };
            newTest.SetMyList(newList);
            newTest.SetMyList(testList);
            #endregion
            if (newList == testList)
            {
                foreach (var item in mytest.GetMyList())
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                foreach (var item in newTest.GetMyList())
                {
                    Console.WriteLine(item);
                }
            }
            Console.Read();
        }
    }
    public class Test
    {
        List<string> MyList;
        public Test()
        {
            MyList = new List<string>();
        }
        public List<string> GetMyList()
        {
            return MyList;
        }
        public void SetMyList(List<string> myList)
        {
            MyList = new List<string>();
            MyList = myList;
        }
    }
}
