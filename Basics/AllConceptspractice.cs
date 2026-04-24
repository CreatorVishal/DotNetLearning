

namespace Basics
{
    public class AllConceptspractice
    {

        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public void TakeandMultiply(int a , int b)
        {
            WriteLine("Enter first number:");
            int a1= Convert.ToInt32(Console.ReadLine());
            WriteLine("Enter second number:");
            int b1= Convert.ToInt32(Console.ReadLine());
            int result = Multiply(a1, b1);
            WriteLine("Result: " + result);

        }
    }
    public class StudenT
    {
       public int Age22 { get; set; }
        public string Name22 { get; set; }

        public void setData(string name, int age)
        {
            Name22 = name;
            Age22 = age;
        }
        public void Display()

        {
            WriteLine("Name is " + Name22);
            WriteLine("Age is " + Age22);
        }
    }

    //Inheritance
    public class Animal1
    {
        public void Sound()
        {
            WriteLine("Animal makes a sound");
        }
    }

    public class Dog1 : Animal1
    {
        public void Bark()
        {
            WriteLine("Dog barks");
        }

    }

    //Overloading

    public class loadingConcept
    {
        public void Multiply(int a, int b)
        {
            WriteLine("Multiplication of two numbers: " + (a * b));
        }
        public void Multiply(int a, int b, int c)
        {
            WriteLine("Multiplication of three numbers: " + (a * b * c));
        }
    }

    //Overriding and hiding

    public class Animal3
    {
        public virtual void Sound()
        {
            WriteLine("Animal makes a sound");
        }
    }
    public class Dog3 : Animal3
    {
        //public override void Sound()
        public new void Sound()
        {
            base.Sound();

            WriteLine("Dog barks");
        }
    }

    //Abstract and Interface

    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Circle3 : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    public abstract class Vehicle
    {
        public abstract void Start();

        public void Stop()
        {
            Console.WriteLine("Vehicle stopped");
        }
    }
    public class Car2 : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Car started");
        }
    }
    public class Bike: Vehicle
    {
        public override void Start()
        {
            Console.WriteLine("Bike started");
        }
    }

    //Interface
    public interface IAnimal
    {
        public void sound();
    }
    public class Dog4 : IAnimal { 
        public void sound()
        {
            Console.WriteLine("Dog barks");
        }

    }


    public interface IRun1
    {
        void Run1();
    }

    public interface IEat
    {
        void Eat();
    }

    public class Human : IRun1, IEat
    {
        public void Run1()
        {
            Console.WriteLine("Human runs");
        }

        public void Eat()
        {
            Console.WriteLine("Human eats");
        }
    }

    public class ListPractice { 
        public void ListExample()
        {
            List<int> numbers= new List<int>();
            numbers.Add(10);
            numbers.Insert(1, 345678);
            numbers.Capacity = 20;
            for(int i=0;i< 6; i++)
            {
                WriteLine("Enter no.");
                int numbers1= Convert.ToInt32(Console.ReadLine());
                    numbers.Add(numbers1);
            }
            foreach (int num in numbers)
            {
                Write(num+ " ");
            }

            List<int> numberonly5= new List<int>();
            foreach (int num2 in numberonly5)
            {
                if (num2<5)
                {
                    WriteLine("Enter no....");
                    int numbers2 = Convert.ToInt32(Console.ReadLine());
                    numberonly5.Add(numbers2);



                }


            }
            foreach (int num in numberonly5)
            {
                Write(num + " ");
            }


            }
    }
}
