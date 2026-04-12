

namespace Basics
{
    public abstract class Animal2 {
        public abstract void makeSound();
    }
    public  class Dog : Animal2
    {
        public override void makeSound()
        {
            WriteLine("Woof");

        }
    }
    public  class Cat4: Animal2
    {
        public override void makeSound()
        {
            WriteLine("Meow");
        }
    }


    //public abstract class Jk
    //{
    //    public int age { get; set; }
    //    public string name = "Vishal";
    //    public abstract void display();
    //    public void run()
    //    {
    //        WriteLine("asdfghjkl");
    //    }
    //    public Jk()
    //    {
    //        WriteLine("Normal constructor");
    //    }
    //    public Jk(int number, string fullName):this() 
    //    {
    //        WriteLine(number);
    //        WriteLine(fullName);

    //    }
    //}

    //public abstract class Jk1 : Jk
    //{
    //    public Jk1() : base(23, "Vishal")
    //    {
    //    WriteLine("second Abstract class constructor");
    //    }
    //    public void display1()
    //    {
    //        WriteLine("Child class display method");



    //    }
       
    //}
    //public class Montu : Jk1
    //{
    //    public override void display(){
    //        age=23;
    //        WriteLine("Montu ka disp func.");
    //    }
    //    public Montu():base()
    //    {

    //    }
        


    //}
}
