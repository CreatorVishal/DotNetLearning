

namespace Basics
{

    //internal delegate int calculator(int x1, int y1);
    //internal class Test
    //{
    //    public int add22(int a, int b)
    //    {
    //        return a + b;

    //    }
    //    public int sub22(int a, int b)
    //    {
    //        return a - b;

    //    }
    //    public Test()
    //    {
    //        calculator c = add22;
    //        WriteLine(c(4, 5));
    //        calculator d = sub22;
    //        WriteLine(d(4, 5));
    //    }
    //}
    //internal class DelegatesPrac
    //{
    //    public delegate int Transformer();
    //    public Transformer d;

    //    public delegate int Transformer2(int x);
    //    public Transformer2 d2;

    //    public int sum(int x)
    //    {
    //        return x * x;
    //    }
    //    public int sum2(int x)
    //    {
    //        return x * x * x;
    //    }

    //    //int y=> y * 5;


    //    internal DelegatesPrac()
    //    {
    //        d2 = sum;
    //        WriteLine(d2(4));
    //        d2 = sum2;
    //        WriteLine(d2(4));

    //        //lambda function
    //        d2 = x => x * x;

    //        WriteLine("Lambda function...  " + d2(5));

    //        //WriteLine("Lambda function with expression body...  " + y);











    //    }
    //}

    class Program09
    {
        delegate int MyDelegate(int x);
        delegate int Mydelegate1(int a, int b);


        public delegate void Notify();
        public void Email()
        {
            WriteLine("Email sent");
        }
        public void Sms()
        {
            WriteLine("SMS sent");
        }

        public Program09()
        {
            MyDelegate d = Square;

            WriteLine(d(5));

            d = Cube;
            WriteLine(d(3));

            //Anonymous method

            MyDelegate d1 = delegate (int x)
            {
                return x * x * x * x * x;
            };
            WriteLine(d1(2));
            WriteLine(d1(4));

            //lambda
            MyDelegate d2 = x => x * 5;
            WriteLine(d2(4));

            //square of a number using lambda
            MyDelegate d3 = x => x * x;
            WriteLine(d3(9));
            //cube
            MyDelegate d4 = x => x * x * x;
            WriteLine(d4(10));
            //double
            MyDelegate d5 = x => x * 2;
            WriteLine(d5(20));
            //Even checker
            MyDelegate d6 = x => (x % 2 == 0 ? 1 : 0);

            //Two parameter lambda
            WriteLine("------------------------------------");
            Mydelegate1 d7 = (x, y) => x * y;
            WriteLine(d7(4, 50000));

            //-----------Func-----------------

            Func<int, int, int> Addition = (x, y) => x + y;
            WriteLine(Addition(45, 40));

            Func<int, int> square1 = x => x * x;
            WriteLine(square1(150));

            Func<int, int> cube1 = x => x * x * x;
            WriteLine(cube1(20));

            Func<int, int, int> Maxof2 = (x, y) => x > y ? x : y;
            WriteLine(Maxof2(23, 889));

            Func<int, int> op2;

            op2 = x => x * x;

            WriteLine(op2(5));      
            op2 = x => x * x * x;

            WriteLine(op2(5));

            //Action delegate
            Action msg = () => WriteLine("Hi Vishal,Good morning");
            msg();

            //One Parameter action
            Action<string> msg2 = (name) => WriteLine(name);
            msg2("Vishal sharma");
            //Two parameter action

            Action<string,int> printNA= (name, age) =>
            {
                WriteLine($"{name}, {age}");
            };
            printNA("Vishal Sharma", 25);
            WriteLine("-----------------------------");
            //predicate delegate
            Predicate<int> adult =
    age => age >= 18;

            WriteLine(adult(22));

        }

        int Square(int x)
        {
            return x * x;
        }
        public int Cube(int x)
        {
            return x * x * x;
        }
    }
}
