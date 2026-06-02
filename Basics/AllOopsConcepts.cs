using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    //Class & Object 
    //encapsulation
    public class Electronics
    {
        public string Brand { get; set; }

        public int Price { get; set; }

        //public int Price
        //{
        //    get
        //    {
        //        return _price;
        //    }

        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _price = value;
        //        }
        //        else
        //        {
        //            WriteLine("Price should be greater than 0");
        //        }
        //    }
        //}

        public void PowerOn()
        {
            WriteLine("Powering on the electronic device...");
        }
        //public Electronics(string brand, int price)
        //{
        //    Brand = brand;
        //    Price = price;
        //}

        public void ShowElectronics()
        {
            WriteLine($"Brand: {Brand}");
            WriteLine($"Price: {Price}");
        }
    }

    public class Vehicle1
    {
        public string Brand { get; set; }
        public int Price { get; set; }
        public void Start()
        {
            WriteLine("Starting the vehicle...");
        }

    }
    public class Bike1 : Vehicle1
    {
        public void Ride()
        {
            WriteLine("Riding the bike...");
        }
    }

    //Constructor
    public class Practicee
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Practicee()
        {
            WriteLine("Hi I am a constructor");
        }
        //static sirf ek baar run hota h  
        //static Practicee()
        //{
        //    Console.WriteLine("Static Constructor");
        //}
        public Practicee(string Name) : this()
        {
            WriteLine("I am a parameterized constructor");
        }
        public Practicee(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public void Show1()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Price);
        }

    }
    public class Electronics1
    {
        public Electronics1()
        {
            WriteLine("Electronics Constructor");
        }
    }

    public class Mobile1 : Electronics1
    {
        public Mobile1() : base()
        {
            WriteLine("Mobile Constructor");
        }
    }

    //Polymorphism
    //Method Overloading
    public class Calculator2
    {
        public int Add12(int a, int b)
        {
            return a + b;
        }

        public int Add12(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    //Method overriding
    class vehicle2
    {
        public virtual void Start()
        {
            WriteLine("Starting vehicle...");
        }
    }
    class Car32 : vehicle2
    {
        public override void Start()
        {
            WriteLine("Starting car...");
        }
    }

    //Access Modifiers

    class BankAccount
    {
        //Private access modifier: Only accessible within the class
        private int balance = 50000;
        public void show()
        {
            WriteLine($"Balance: {balance}");
        }
    }
    public class Animal22
    {
        //Protected access modifier: Accessible within the class and its derived classes
        protected string species = "Mammal";
    }
    public class Pet : Animal22
    {
        public void ShowSpecies1()
        {
            WriteLine($"Species: {species}");
        }
    }
    //Abstract class and Methods
    public abstract class  Animal12
    {
        public abstract void sound();

        public void eat()
        {
            WriteLine("Eating...");
        }


    }
    public class Dog23 : Animal12
    {
        public override void sound()
        {
            WriteLine("Dog barks");
        }
    }

    //Interface
    interface ICamera
    {
        void TakePhoto();
    }

    interface IMusic
    {
        void PlayMusic();
    }
    class Mobile : ICamera, IMusic
    {
        public void TakePhoto()
        {
            Console.WriteLine("Photo Taken");
        }

        public void PlayMusic()
        {
            Console.WriteLine("Music Playing");
        }
    }


    //----------Test---------
    //Q1
    public class Student009
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Course { get; set; }


        public void Show()
        {
            WriteLine($"Id: {Id}");
           WriteLine($"Name: {Name}");
           WriteLine($"Course: {Course}");

        }
        public void Study()
        {
            WriteLine($"{Name} is Studying");
        }
    }
    //Q2
    public class Mobile009
    {
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Ram { get; set; }

        public void ShowMobileDetails()
        {
            WriteLine($"Brand :{Brand}");
            WriteLine($"Price :{Price}");
            WriteLine($"Ram : {Ram}");
        }
        public Mobile009(string Brand,int Price,int Ram)
        {
            this.Brand = Brand;
            this.Price = Price;
            this.Ram = Ram;

        }
    }

    //Q3
    public class BankAccount009
    {
        public string AccountHolder { get; set; }

        private int Balance;

        public void Deposit(int amount)
        {
            if (amount <= 0)
            {
                WriteLine("Please enter a valid amount");
                return;
            }

            Balance += amount;

            WriteLine($"{amount} Deposited Successfully");
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0)
            {
                WriteLine("Invalid Withdraw Amount");
                return;
            }

            if (amount > Balance)
            {
                WriteLine("Insufficient Balance");
                return;
            }

            Balance -= amount;

            WriteLine($"{amount} Withdraw Successfully");
        }

        public void CheckBalance()
        {
            WriteLine($"Current Balance : {Balance}");
        }
    }
    interface IDeveloper
    {
        void Code();
    }

    interface ITester
    {
        void Test();
    }

    // Multiple inheritance using interfaces
    class Employee1111 : IDeveloper, ITester
    {
        public void Code()
        {
            Console.WriteLine("Employee is writing code");
        }

        public void Test()
        {
            Console.WriteLine("Employee is testing software");
        }
    }
    class Engine
    {
        public void StartEngine()
        {
            Console.WriteLine("Engine Started");
        }
    }

    class Car22
    {
        private Engine engine;

        public Car22()
        {
            engine = new Engine();
        }

        public void StartCar()
        {
            engine.StartEngine();
            Console.WriteLine("Car Started");
        }
    }
    //class Employee111
    //{
    //    private int salary;

    //    public int Salary
    //    {
    //        get { return salary; }

    //        set
    //        {
    //            if (value > 0)
    //            {
    //                salary = value;
    //            }
    //        }
    //    }

    //    public void Show()
    //    {
    //        Console.WriteLine("Salary: " + salary);
    //    }
    //}
    interface IDeveloper150
    {
        void Code();
    }

    interface ITester150
    {
        void Test();
    }

    class Employee150 : IDeveloper150, ITester150
    {
        public void Code()
        {
            Console.WriteLine("Employee is writing code");
        }

        public void Test()
        {
            Console.WriteLine("Employee is testing software");
        }
    }
    public sealed class Calculator1234
    {
        public void Show()
        {
            Console.WriteLine("Sealed Class Example");
        }
    }
    public static class MathHelper
    {
        public static int Square(int num)
        {
            return num * num;
        }
    }
    //Hierarchical Inheritance
    public class PersonX
    {
        public void ShowPerson()
        {
            Console.WriteLine("I am Person");
        }
    }

    public class StudentX : PersonX
    {
        public void Study()
        {
            Console.WriteLine("Student is studying");
        }
    }

    public class EmployeeX : PersonX
    {
        public void Work()
        {
            Console.WriteLine("Employee is working");
        }
    }
    //Multilevel inheritance
    public class LivingThing
    {
        public void Breathe()
        {
            Console.WriteLine("Breathing...");
        }
    }

    public class HumanBeing : LivingThing
    {
        public void Think()
        {
            Console.WriteLine("Thinking...");
        }
    }

    public class Programmer : HumanBeing
    {
        public void Code()
        {
            Console.WriteLine("Writing Code...");
        }
    }
    public class LibraryShelf
    {
        private string[] books = new string[3];

        public string this[int index]
        {
            get
            {
                return books[index];
            }
            set
            {
                books[index] = value;
            }
        }

        public void DisplayBooks()
        {
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
    public interface IMessageService
    {
        void SendMessage();
    }

    public class WhatsAppService : IMessageService
    {
        public void SendMessage()
        {
            Console.WriteLine("Message Sent Through WhatsApp");
        }
    }

    public class NotificationManager
    {
        private readonly IMessageService _messageService;

        public NotificationManager(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify()
        {
            _messageService.SendMessage();
        }
    }
    public class Course
    {
        public string CourseName { get; set; }
        public int DurationMonths { get; set; }

        public Course(string courseName, int durationMonths)
        {
            CourseName = courseName;
            DurationMonths = durationMonths;
        }

        public void ShowCourse()
        {
            Console.WriteLine($"Course : {CourseName}");
            Console.WriteLine($"Duration : {DurationMonths} Months");
        }
    }

    public class UniversityStudent
    {
        private int marks;

        public string StudentName { get; set; }

        public int Marks
        {
            get { return marks; }
            set
            {
                if (value >= 0 && value <= 100)
                    marks = value;
                else
                    Console.WriteLine("Invalid Marks");
            }
        }

        public Course StudentCourse { get; set; }

        public UniversityStudent(string name, int marks, Course course)
        {
            StudentName = name;
            Marks = marks;
            StudentCourse = course;
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"Name : {StudentName}");
            Console.WriteLine($"Marks : {Marks}");
            Console.WriteLine($"Course : {StudentCourse.CourseName}");
        }
    }

    public class UniversityManager
    {
        private List<UniversityStudent> students = new();

        public void AddStudent(UniversityStudent student)
        {
            students.Add(student);
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("===== Student List =====");

            foreach (var student in students)
            {
                student.DisplayStudent();
                Console.WriteLine("------------------");
            }
        }
    }
    public class BankDemo
    {
        private double balance;

        public BankDemo(double amount)
        {
            balance = amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new Exception("Insufficient Balance");
            }

            balance -= amount;
            Console.WriteLine($"Withdraw Success. Remaining Balance = {balance}");
        }
    }
    public class Distance
    {
        public int Meter { get; set; }

        public Distance(int meter)
        {
            Meter = meter;
        }

        public static Distance operator +(Distance d1, Distance d2)
        {
            return new Distance(d1.Meter + d2.Meter);
        }

        public void Show()
        {
            Console.WriteLine($"Distance = {Meter} Meter");
        }
    }
}
