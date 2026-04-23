
namespace Basics
{
    public class BasicConcepts 
    {
        int age = 23;
        string name = "Vishal sharma ";

               
        public void Sum44(int a,int b)
        {
            int result = a + b;
            Console.WriteLine("Sum: " + result);
        }

        public void Display()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Age: " + age);
        }

    }
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero");
                return 0;
            }

            return (double)a / b;
        }
    }
    //Generics
    public class Box<T>
    {
        public T Value { get; set; }

        public void swap4(ref T a,ref T b)
        {
            T temp = a;
            a = b;
            b = temp;

        }
    }
    public class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }
        //public Pair(T1 first, T2 second)
        //{
        //    First = first;
        //    Second = second;
        //}
        public void Display22()
        {
            Console.WriteLine("First: " + First);
            Console.WriteLine("Second: " + Second);
        }

    }
    public class Store<T>
    {
        T data { get; set; }

        public void Add22(T item)
        {
            data=item;
        }
        public T Get()
        {
            return data;
        }

    }

}
