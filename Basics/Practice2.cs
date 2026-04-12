
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
        public  Practice3(int age, string name)
        {
            this.age4 = age;
            this.name = name;
        }
        public abstract void display();
        
        
    }
    public  class Pp : Practice3
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
}
