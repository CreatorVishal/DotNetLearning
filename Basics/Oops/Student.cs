//public class Testing
//{
//    static Testing()
//    {
//        WriteLine("This is a static constructor.....");
//    }
//    public static void display()
//    {
//        WriteLine("Display function");



//    }
//}

 class Student1
{
    public int Age { get; set; }
    public string Name { get; set; }

    //public Student1(int Age, string name)
    //{
    //    if (Age < 0)
    //    {
    //        throw new Exception("Age can not be negative "); 
    //    }
    //    this.Age = Age;
    //    Name = name;

    //}

    //public void printDetails()
    //{
    //    WriteLine($"{Age} , {Name}");

    //}

    public Student1(string name)
    {
        Name = name;
        Age = 22; //default
    }
    public Student1(int age, string name)
    {
        if (age < 0)
        {
            throw new ArgumentException("Invalid age.. ! ");
        }
        Name = name;
        Age = age;
    }
    public bool IsAdult()
    {
      return Age>=18;
        
    }
    public string GetInfo()
    {
        return $"{Name},{Age}";
    }
    public static void Print(object data)
    {
        if (data is int num )
        {
            WriteLine("Number : " + num);
            WriteLine(num * num);
        }
        else if (data is string str)
        {
            WriteLine("String : " + str);
            //str.Reverse.ToArray
            string reversed = new string(str.Reverse().ToArray());
            Console.WriteLine("Reversed : " + reversed);
        }
        else
        {
            WriteLine("Unknown type : " + data);
        }

        //WriteLine(data);
    }
    public static void pppp()
    {
        Print("Vishal sharma...");
    }
    
}
