

namespace Basics
{
    internal class Practice1 
    {
        public int a = 23;
        public int b = 45;
        public string Name { get; set; }
        public int Age { get; set; }

        //public Practice1()
        //{ }//default constructor;
        public Practice1(string name,int age) //parameterized constructor
        {
            this.Name = name;
            this.Age = age;
        }
        public void display()
        {
            int Sum=AddFunc(34,67);
            WriteLine($"Sum of 34 and 67 is: {Sum}");
            int Result1=AddFunc(34,67,89);
            WriteLine($"Sum of 34, 67 and 89 is: {Result1}");
            Console.WriteLine($"Name: {Name}, Age: {Age}");
            WriteLine($"Before swapping: a = {a}, b = {b}");
            Swap(ref a, ref b);

            int num1, num2;

            GetNumber(out num1,out num2);
            WriteLine($"Numbers from GetNumber method: num1 = {num1}, num2 = {num2}");

            //string str = "this is a string";
            //string upper = str.ToUpper();
            //string lower = str.ToLower();
            //string s = str.IndexOf("s");
            //bool s = str.EndsWith("string");

        }
        public int AddFunc(int a , int b){
            return a+b;
            }

        //Method overloading
        public int AddFunc(int a, int b, int c)
        {
            return a + b + c;
        }
        public int AddFunc(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }

        public void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
            WriteLine($"After swapping: a = {x}, b = {y}");
        }
        public void GetNumber (out int x,out int y) {
            x = 10;
            y = 20;
        }

        ////const

        //const int age_limit=18;
        //age_limit=22;//Not possible
        //---------------------------------------------

        //string parsing in main method

        //string str="123";
        // int number =int.Parse(str);
        //----------------------------------------------

        //Type Casting

        //decimal d = 12323.12343m;
        //int number = Convert.ToInt32(d);

        








    }

}
