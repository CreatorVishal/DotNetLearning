

namespace Basics
{

    internal delegate int calculator(int x1,int y1);
    internal class Test
    {
        public int add22(int a, int b)
        {
            return a + b;

        }
        public int sub22(int a, int b)
        {
            return a - b;

        }
        public Test() {
            calculator c = add22;
            WriteLine(c(4, 5));
            calculator d = sub22;
            WriteLine(d(4, 5));
        }
    }
    //internal class DelegatesPrac
    //{
    //    public delegate int Transformer() ;
    //    public Transformer d;
        
    //    public delegate int Transformer2(int x);
    //    public Transformer2 d2;

    //    public int sum(int x)
    //    {
    //        return x * x;
    //    }
    //    public int sum2(int x)
    //    {
    //        return x * x*x;
    //    }

    //    //int y=> y * 5;


    //    internal DelegatesPrac(){
    //        d2 = sum;
    //        WriteLine(d2(4));
    //        d2 = sum2;
    //        WriteLine(d2(4));

    //        //lambda function
    //        d2=x=>x*x;

    //        WriteLine("Lambda function...  " + d2(5));

    //        //WriteLine("Lambda function with expression body...  " + y);
            

           


            



    //    }
    //}
}
