

namespace Basics.Oops
{

    public partial struct Mystruct
    {
        public int? age;
        public string? name;
        public Mystruct(int age, string name)
        {
            this.age = age;
            this.name = name;
        }

    }
    public  partial struct Mystruct
    {
        public int? data;
        public string? surname;
        public void display()
        {

            WriteLine($"Hi {data}, {surname},{age},{name}");
            Jk2 j1 = new Jk2(); 
        }
    }
    public class Jk
    {
        public Jk():this("Vishal"){
            WriteLine("Base const.");
                }
        public Jk(string name){
            WriteLine($"second const.{name}");
                }
        public Jk(int age, string fullname):this()
        {
            WriteLine($"third const.{age}, {fullname}");
        }
    }
    public class Jk2:Jk{
        public Jk2():base(23,"Vishal sharma") {
            WriteLine("Derived const");
        }

    }

}

