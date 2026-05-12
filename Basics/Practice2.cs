
namespace Basics
{

    //Sealed class is a class that cannot be inherited. It is used to prevent other classes from inheriting from it. A sealed class can be useful when you want to create a class that is not
    //public sealed  class Practice2
    //{
    //    public int age4;
    //    public string name;
    //    public Practice2(int age, string name)
    //    {
    //        this.age4 = age;
    //        this.name = name;
    //    }

    //}
    //class & object  
    public class Student110 {
        public string name { get; set; }
        public int age { get; set; }
        public int marks { get; set; }
        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
        }
    }
    public class Laptop
    {
        string brand;
        int price;
        string Ram;
        public void show()
        {
            Console.WriteLine($"Brand: {brand}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Ram: {Ram}");
        }
        public Laptop(string brand, int price, string Ram)
        {
            this.brand = brand;
            this.price = price;
            this.Ram = Ram;
        }
    }

    //Interface 
    interface INotification
    {
        void Send();
    }
    class EmailNotification : INotification
    {
        public void Send()
        {
            WriteLine("Email notification sent.");
        }
    }
    class SmsNotification : INotification
    {
        public void Send()
        {
            WriteLine("SMS notification sent.");
        }
    }
    public class Practice2
    {
        public int age4;
        public string name;
        public Practice2(int age, string name)
        {
            this.age4 = age;
            this.name = name;
        }

    }
    public class Child : Practice2
    {
        public Child(int age, string name) : base(age, name)
        {

        }

    }
    public abstract class Practice3
    {
        public int age4;
        public string name;
        public Practice3(int age, string name)
        {
            this.age4 = age;
            this.name = name;
        }
        public abstract void display();


    }
    public class Pp : Practice3
    {
        public Pp() : base(33, "Montu")
        {
            WriteLine("Child class constructor called and base class constructor called");

        }
        public override void display()
        {
            WriteLine($"{age4},{name}");
        }
    }

    //Encapsulation
    public class Enc
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0) { 
                    age = value;

                }
                else
                {
                    Console.WriteLine("Age must be greater than 0.");
                }
            }
        }
    }
}
