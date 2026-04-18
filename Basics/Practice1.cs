

namespace Basics
{
    internal class Practice1 
    {
        public string name { get; set; }
        public int age { get; set; }

        //public Practice1()
        //{ }//default constructor;
        public Practice1(string name,int age) //parameterized constructor
        {
            this.name = name;
            this.age = age;
        }
        public void display()
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }



    }
}
