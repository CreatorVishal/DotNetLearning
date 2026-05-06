
namespace Basics
{
    internal class Apractice
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Marks { get; set; }

        public void Display()
        {
            WriteLine($"{Name} is {Age} years old and has scored {Marks} marks.");
        }

        public void Division(int a, int b)
        {
            Console.WriteLine("Int Division: " + (a / b));
            Console.WriteLine("Double Division: " + ((double)a / b));
        }

        public void CheckEvenorOdd(int number)
        {
            if (number % 2 == 0)
            {
                WriteLine($"{number} is an even number.");
            }
            else
            {
                WriteLine($"{number} is an odd number.");
            }
        }
        public void Largest(int num1, int num2, int num3)
        {
            if (num1 > num2 && num1 > num3)
            {
                WriteLine($"{num1} is the largest number.");
            }
            else if (num2 > num1 && num2 > num3)
            {
                WriteLine($"{num2} is the largest number.");
            }
            else
            {
                WriteLine($"{num3} is the largest number.");
            }
        }
        public void Grade(int marks)
        {
            if (marks >= 90)
            {
                WriteLine("Grade: A");
            }
            else if (marks >= 80)
            {
                WriteLine("Grade: B");
            }
            else if (marks >= 70)
            {
                WriteLine("Grade: C");
            }
            else if (marks >= 60)
            {
                WriteLine("Grade: D");
            }
            else
            {
                WriteLine("Fail");
            }
        }

        public void Sumtillend(int n)
        {
            int count = 0;
            for (int i = 0; i <= n; i++)
            {
                count += i;
            }
            WriteLine($"The sum of numbers from 0 to {n - 1} is: {count}");

        }
        public void Reverse(int number)
        {
            int rev = 0;

            while (number > 0)
            {
                int digit = number % 10;
                rev = rev * 10 + digit;
                number = number / 10;
            }

            Console.WriteLine("Reversed number is: " + rev);
        }


    }
    public class Students
    {
        public string Name { get; set; }
        public int Marks { get; set; }
        public void ShowResults()
        {
            if (Marks > 50)
            {
                WriteLine($"{Name} has passed with {Marks} marks.");

            }
            else
            {
                WriteLine($"{Name} has failed with {Marks} marks.");
            }
        }
    }

    //Encapsulation example
    //first way to encapsulate is by using properties with private fields
    class Stud
    {
        private int marks;
        public void SetMarks(int m)
        {
            if(m>=0 && m <= 100){
                marks = m;
            }
            else {
                WriteLine("Invalid marks");
            }
        }
        public int GetMarks()
        {
            return marks;
        }
    }
    //second way to encapsulate Property with backing field + validation

    class stud2
    {

        private int marks;
        public int id { get; }
        public stud2(int id)
        {
            this.id = id;
        }
        public int Marks
        {
            get { return marks; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    marks = value;
                }
                else
                {
                    WriteLine("Invalid marks");
                }
            }
        }

    }

    //Constructor example

    class Joker
    {
        public string Name;
        public int Age;
        //Default constructor
        public Joker() : this("Unknown", 0)
        {
            WriteLine("Defconstructor called"); 
       }
        public Joker(string name):this(name, 0)
        {
            //Name = name;
            WriteLine("1 param constructor");

        }
        //Parameterized constructor
        public Joker(string name,int age)
        {
            WriteLine("Main constructor");
            Name = name;
            Age = age;
        }


        //Copy constructor
        public Joker(Joker other)
        {
            Console.WriteLine("Copy constructor called");
            Name = other.Name;
            Age= other.Age;
        }
    }

    //Inheritance example

    class person
    {
        //public person()
        //{
        //    WriteLine("parent constructor called");
        //}
        //public int Marks;

        public person(int marks)
        {
            WriteLine("Marks : " + marks);
        }
        //public void ShowMarks()
        //{
        //    WriteLine("Parent class method called");
        //    WriteLine($"Marks: {Marks}");
        //}
        public void Show()
        {
            WriteLine("Parent class method called");
        }

    }
  class stu: person
    {
        public stu() : base(89) 
        {
            WriteLine("Child constructor called ");
        }
        //public string Name;
        //public void ShowName()
        //{
        //    WriteLine("Child class method called");
        //    WriteLine($"Name: {Name}");
        //}
        //public stu(string Name, int Marks) : base(Marks)
        //{
        //    this.Name = Name;
        //    Console.WriteLine("Child constructor");
        //}
        public void Show()
        {
            WriteLine("Child class method called");
        }


    }

    class Carc
    {
        public string Brand;
        public int Speed;
        public string Color;
        public void Start()
        {
            WriteLine($"{Brand} Started");
        }
        public void Stop()
        {
            WriteLine($"{Brand} Stopped");
        }
        public void Display()
        {
            WriteLine($"Brand: {Brand}, Speed: {Speed} km/h, Color: {Color}");
        }

    }
    class Calculator66{
        public void Add2(int a, int b)
        {
            WriteLine($"Sum: {a + b}");
        }
        public void Add2(int a , int b,int c)
        {
            WriteLine($"Sum: {a + b + c}");
        }
        public void Add2(double a , double b)
        {
            WriteLine($"Sum: {a + b}");
        }
    }

    //Method Overriding
    class Animal11
    {
        public virtual void Sound()
        {
            WriteLine("Animal sound");
        }
    }
    class Dog11 : Animal11
    {
        public override void Sound()
        {
            WriteLine("Dog Sound");
        }
    }


}
