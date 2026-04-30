using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    internal class LinqPractice
    {
        public LinqPractice() { 

            //Where with only one condition 
            List<int> list= new List<int>() { 10,20,30,40,50,60};
            var result = list.Where(x => x > 10);
            foreach(var item in result)
            {
                Write(item+" ");
            }
            WriteLine();
            //Where with Multiple conditions
            var result2 = list.Where(x => x > 10 && x < 50);

            foreach (var item in result2)
            {
                Write(item + " ");
            }
            WriteLine();

            //Select(Transform)
            var res = list.Select(x => x * 2);
            foreach(var item in res)
            {
                Write(item + " ");
            }
            WriteLine();

            //Chaining
            var chainres = list.Where(x => x > 10)
                .Select(x => x * 10);
            foreach(var item in chainres)
            {
                Write(item + " ");
            }
            WriteLine();

           
        }

    }
}
