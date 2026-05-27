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
    class Employee : IDeveloper, ITester
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
}
