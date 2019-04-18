using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    public class LamdbaTest
    {

        public void FunWithLambda()
        {
            List<int> list = new List<int>();
            list.Add(2); list.Add(3); list.Add(1);

            var list2 = list.Select(x => x + 1);

            var list3 = list.Select(x => x * 2);

            Func<int, int> expression = x => x + 1;
            //Func<int,int,int, int> expression2 = (x,y,z)=> x + 1;

            var list2bis = list.Select(expression);

            //List<object> ooo = new List<object>();
            //ooo.Where();
            //ooo.Select();


            


        }

          
    }
}
