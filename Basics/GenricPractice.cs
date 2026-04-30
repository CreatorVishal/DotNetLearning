using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{

    //Genric Constraints 
    //class,struct, new etc;

    public class Truck<T> where T:class
    {
        //property genric
      public  T engine { get; set; }

    }
    public class Train<T> where T: GenuineParts, new()
    {
        //property genric
      public  T engine { get; set; }

        public Train()
        {
             var obj = new T();

            if(obj is spareParts access)
            { 
            WriteLine(access.since);
            access.disp();
           
            }

            obj.disp();
            WriteLine(obj.since);
            }

        public T CreateOBject()
        {
            //var obj = new T();
            return new T();
        }
    }





    public class GenricPractice
    {
        public GenricPractice()
        {
            //    Gen<int> practice = new();
            //    Gen<string> pre = new();

            //    practice.amount = 20000;
            //    int res=practice.Calc(24);
            //    WriteLine(pre.Calc("Hello"));
            //    WriteLine(res);
            //    WriteLine("-------------");
        //    Truck<int> tck = new();
        //tck.engine = 560;

        //    Truck<float> tuc2 = new();
        //tuc2.engine = 546.45f;

            Truck<string> tuck = new();
            tuck.engine = "Mercedes Benz";


            Train<spareParts> ti = new();
            var responseOBject = ti.CreateOBject();


            responseOBject.disp();





        }
    }

    public interface GenuineParts
    {
        public int since { get; set; }
        public void disp();
    }

    public class spareParts :GenuineParts
    {
        public spareParts() { }
        
        public int since { get; set;} = 1971;

        public void disp()
        {
            WriteLine("Hello i am disp method");
        }

    }

    //public class Gen<T>
    //{
    //    public T age;
    //    public T amount { get; set; }
    //    public T Calc(T age)
    //    {
    //        return age;
    //    }
    //}



    
}
