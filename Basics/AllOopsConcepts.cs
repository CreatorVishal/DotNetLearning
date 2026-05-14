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
        public Practicee(string Name):this()
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
        public Mobile1() :base()
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
}
