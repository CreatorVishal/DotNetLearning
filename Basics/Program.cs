using Basics.France;
using Tx=Basics.Texas;
using Basics.Oops;
using Basics;
using System.Text.Json;
using System.Text.Json.Serialization;


record order(int age , double salary,string fullName);
 internal record Job {
    public int job_no { get; init; }
    public string job_name { get;init; }
   public Job(int JN, string JJ) {
      job_no =JN;
      job_name =JJ;
    }

  
}
public enum CountryCode{
   Ind= +91,
    US= +1,
    UK= +44,        


}

class Ss
{
    private int cust_age;
    public int custage1 {
        get { return cust_age; }
        set { if (value > 0)
            {
                cust_age = value;
            }
            else {
                WriteLine("Invalid age ");
            }
        }

    }
}
class Practice
{
    public readonly int Asdf = 45; 
    public required int Fett { get;set; }
    private double salary;

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value > 1000)
            {
                salary = value;

            }
            else
            {
                WriteLine("Invalid Salary");
            }

        }
    }
    public double AnnualSalary{
        get { return salary * 12; }
    } 
}
    public class Program
    {

    public static void Main(string[] args)
    {

        WriteLine("Hello, World!");
        int age;
        WriteLine("Enter age : ");
        bool Success = int.TryParse(ReadLine(), out age);

        if (Success)
        {
            WriteLine($" Your age is :{age}");
        }
        else
        {
            WriteLine("Invalid Age...");
        }
        #region
        int decimalNotation = 2_000_000;
        int binaryRotation = 0b_0001_1110_1000_0100_1000_0000;
        int hexaDecimalNotation = 0x_001E_8480;
        WriteLine($"{binaryRotation:N0}");
        #endregion

        //unary operator 
        int x = 2;
        WriteLine(x++);
        WriteLine(++x);
        WriteLine(x--);
        WriteLine(--x);

        Type theTypeOfAnInteger = typeof(int);
        string nameOfVariable = nameof(x);
        WriteLine(nameOfVariable);

        string? eName = null;

        int? len = eName?.Length ?? 30;
        WriteLine(len);

        int? age1 = 32;
        WriteLine(age1 ?? 45);

        //----------------------

        int p = 6;
        p += 3;
        p -= 3;
        p /= 3;
        p *= 3;

        WriteLine(p);


        WriteLine(3 << 3); //24
        WriteLine(4 >> 2);
        int y = 5;
        WriteLine($"y << 3 | {y << 3,7} | {y << 3:B8}");
        //char ch = 'd';

        WriteLine(typeof(int));//System.Int32
        WriteLine(nameof(y));//y
        WriteLine(sizeof(char));//2


        //-------------------------


        object one = "Vishal";
        string? cdd = one as string;
        if (one is string)
        {
            WriteLine("Yes You are right...");
        }
        WriteLine(cdd.Length);


        string password = "ninja";
        if (password.Length < 8)
        {

            WriteLine("Your password is too short. Use at least 8 chars.");

        }

        else
        {
            WriteLine("Your password is strong.");
        }

        string GetStatus(int score)
        {
            if (score < 50)
            {
                return "Fail";
            }
            return "Pass";
        }

        WriteLine(GetStatus(30));

        //---------/
        int number = Random.Shared.Next(minValue: 1, maxValue: 7);
        WriteLine($"My random number is {number}");
        switch (number)
        {
            case 1:
                WriteLine("One");
                break; // Jumps to end of switch statement.
            case 2:
                WriteLine("Two");
                goto case 1;
            case 3: // Multiple case section.
            case 4:
                WriteLine("Three or four");
                goto case 1;
            case 5:

            default:
                WriteLine("Default");
                break;
        }
        WriteLine("After end of switch");
    A_label:
        WriteLine($"After A_label");

        //Dog obj = new Dog();
        //obj.sound();
        Operation obj = new Operation();


        string[,] str =
        {
    { "Vishal", "Montu", "Kapil" },
    { "Rani", "Deepika", "Ananya" }
};

        for (int i = 0; i < str.GetLength(0); i++) // rows
        {
            for (int j = 0; j < str.GetLength(1); j++) // columns
            {
                Console.WriteLine($"[{i},{j}] = {str[i, j]}");
                WriteLine(str[i, j]);
            }
        }
        ;



        WriteLine(str.GetLowerBound(0));
        WriteLine(str.GetUpperBound(1));

        //jagged array

        string[][] jagged =
        {
    new[] { "Alpha", "Beta", "Gamma" },
    new[] { "Anne", "Ben", "Charlie", "Doug" },
    new[] { "Aardvark", "Bear" }
};

        try
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    WriteLine(jagged[i][j] + " ");

                }
                WriteLine();


            }

        }
        catch (IndexOutOfRangeException)
        {
            WriteLine("Index out of bound");
        }


        string input = ReadLine();

        try
        {
            int num = int.Parse(input);
            WriteLine(num);

        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }

        try
        {

            int num3 = int.Parse(ReadLine());
        }
        catch (FormatException)
        {
            WriteLine("Wrong format");
        }
        catch (OverflowException)
        {
            WriteLine("Number you entered is big ");
        }
        finally
        {
            WriteLine("Always Run");
        }
        if (number < 0)
        {
            throw new Exception("Invalid num");
        }
        ;

        //public int ok = 0; //field
        //public int num5 {get;set;} // property

        //Types of field 
        //const int Max = 100;//constant

        //Readonly
        //readonly int age3;

        //public Person()
        //{
        //    age3 = 25;
        //}

        //Paris p1 = new(); //yha error aata is liye hmne ek namespace ko alias bna diya  
        //like this  -------- alias = nickname of namespace 
        //using Basics.France;
        //using Tx=Basics.Texas;Now we can use easily 

        Paris2 p1 = new();
        Tx.Paris p2 = new();

        Student1 s1 = new Student1("Vishal sharma");
        Student1 s2 = new Student1(22, "Vishal sharma");

        //s1.name = "Vishal";
        //s1.age = 22;

        WriteLine(s1.Name);
        WriteLine(s1.Age);
        WriteLine(s2.Name);
        WriteLine(s2.Age);
        WriteLine(s1.IsAdult());
        //s1.printDetails();
        WriteLine(s1.GetInfo());
        WriteLine("--------------------------------------------------------");

        List<Student1> students = new List<Student1>();

        students.Add(new Student1(23, "Vishal"));
        students.Add(new Student1(17, "Rahul"));
        students.Add(new Student1("Aman")); // default age
        foreach (var s in students)
        {
            WriteLine(s.GetInfo());
        }



        int[] num2 = { 10, 20, 30, 40 };
        foreach (int r3 in num2)
        {
            WriteLine(r3);
        }

        int sum2 = 0;

        foreach (int x2 in num2)
        {
            sum2 += x2;
        }
        WriteLine(sum2 + " ");

        Student1.Print(10);
        Student1.Print("Vishal Sharma");
        Student1.pppp();

        object? data = null;
        string? str4 = data as string;
        if (str4 != null)
        {
            WriteLine(str4);

        }

        WriteLine("---------------------------");
        Mystruct S2 = new Mystruct(23, "Vishal");

        S2.display();
        S2.display2();
        //string methods
        /* 
        Length
        ToUpper(), ToLower()
        Trim(), TrimStart(), TrimEnd()
        Contains("ell")
        StartsWith("he"), EndsWith("lo"),
        IndexOf('l') 
        Substring(1,3)
        Replace('l','x')
        Split(',');
        string.join("-",arr);
        "hello".Equals("hello");

        {
        string.Compare("a","b") // -1
        Return ValueMeaning0Dono strings bilkul barabar hain.Negative (< 0)s1, s2 se pehle aata hai (Alphabetical order).Positive (> 0)s1, s2 ke baad aata hai.

        }
        Console.WriteLine(string.IsNullOrEmpty(s)); // 
        Console.WriteLine(string.IsNullOrWhiteSpace(s)); // true 
        string result = string.Concat("Hello", " ", "World");


        string original = "Hello";

        // 1. String ko char array mein badlo
        char[] charArray = original.ToCharArray();

        // 2. Array ko reverse karo
        Array.Reverse(charArray);

        // 3. Wapas string banao
        string reversed = new string(charArray);

        Console.WriteLine(reversed); // Output: olleH



         */
        Des d1 = new() { name = "Vishal sharma", age = 22 };
        var (name, age3) = d1;

        WriteLine($"Name : {name}, Age : {age3}");
        Ss s11 = new Ss();
        WriteLine("------------------------------------------------------");
        WriteLine(s11);
        WriteLine("------------------------------------------------------");
        s11.custage1 = 23;
        WriteLine(s11.custage1);
        //Practice prac = new Practice();
        //prac.Salary = 5000;
        //WriteLine(prac.Salary);
        //WriteLine(prac.AnnualSalary);

        var order1 = new order(22, 5000000, "Vishal Sharma");
        var order2 = new order(22, 5000000, "Vishal Sharma");

        WriteLine(order1 == order2); // true, because record types have value-based equality

        var order3 = order1 with { salary = 6000000 }; // creating a new record with modified salary

        WriteLine(order1);
        WriteLine(order3);
        var (age5, salary5, fullNAME) = order1;
        WriteLine($"{order1.age},{order1.salary}");

        var j1 = new Job(1, "Software developer ");

        WriteLine(j1);

        WriteLine(CountryCode.Ind);

        Pp obj2 = new Pp();
        obj2.display();

        //Montu n = new();
        //n.display();
        //n.display1();


        Dog dg = new();
        dg.makeSound();

        Cat4 ct = new();
        ct.makeSound();
        Generics<int> obj445 = new Generics<int>();
        obj445.Run<int, string>(10, "Vishal");

        DelegatesPrac Dele = new();

        Func<int, float, float> M = (a, b) => a * b;

        float result = M(2, 3.2f);

        YieldConcept yc = new();
        foreach (var num in yc.GetNumbers())
        {
            WriteLine(num);
        }
        var dj = yc.GetPersonInfo();
        WriteLine(dj.name);
        WriteLine(dj.age);
        TuplePrac qq = new();

        //Test99 tt = new();
        OperatorOverloadingConcept jj = new();
        OperatorOverloading nn = new();
        unSafeStackallocExercise us = new unSafeStackallocExercise();
        us.normalmethod();

        //Records


        var st1 = new Student("Vishal", 22);
        var st2 = new Student("Vishal", 22);
        WriteLine(st1 == st2); // true, because record types have value-based equality
        //st1.Name="Vishalsharma" Not allowed because record types are immutable by default

        WriteLine(st1.Name);
        WriteLine(st2.age);

        var st3 = st1 with { age = 25 };
        WriteLine(st3.age);

        WriteLine("--------------------------------------");
        var a1 = new A(5);
        var a2 = a1;

        a2.x = 10;

        Console.WriteLine(a1.x);
        Console.WriteLine(a2.x);

        var c1 = new Car("Fortuner", 2026);
        var c2 = new Car("Scorpio", 2026);

        c1.DisplayInfo();
        c2.DisplayInfo();
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append("Vishal");
        sb.Append("Sharma");
        sb.AppendLine("Hii");
        sb.Insert(0, "Hiiiiiiiiii");
        sb.Remove(0, 10);
        WriteLine(sb);

        string text = "Hello Vishal";

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        WriteLine(bytes);



        byte[] b = { 70, 34, 34, 23, 3, 4, };
        string result10 = Encoding.UTF8.GetString(b);
        WriteLine(result10);

        WriteLine("----------------------------Practice1.cs-----------------------------");
        //Practice1 Pr1 = new Practice1("Vishal", 22);
        //Pr1.display();

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

        //WriteLine("C:\nProgram");//isme new line me print hoga but agr same krna ho to @ use kro 
        //WriteLine(@"C:\nProgram");//same as it is print hoga 


        //double pi = 3.14;
        //Write(Math.Round(pi));
        //Write(Math.Floor(pi));
        //Write(Math.Abs(pi));
        //Write(Math.Ceiling(pi));
        //Write(Math.Clamp(11, 0, 10));//10
        //Write(Math.Clamp(8, 0, 10));//8
        //Write(Math.Clamp(-1, 0, 10));//0
        //WriteLine(Math.Min(12, 15));
        //WriteLine(Math.Max(12, 15));
        //WriteLine(Math.Pow(2, 5));//32

        //Random number

        //Random r = new();
        //WriteLine(r.Next());//iski range bhi de skte h WriteLine(r.Next(0,11));
        //WriteLine(r.NextDouble());//o se 1 tk ka no. lega 


        //int[] arr = { 10, 20, 30, 40, 50 };
        //int sum = 0;

        //for (int i = 0; i < arr.Length; i++)
        //{
        //    sum += arr[i];
        //}

        //Console.WriteLine("Sum of array = " + sum);

        //WriteLine();
        //WorkingwithFiles wf = new WorkingwithFiles();
        //wf.CreateFile();
        //Filesmanagement.WriteFile();
        //UserInput1.GetUserInput();
        //readingFiles.readFiles();


        ////////////////////////////////////
        ///

        BasicConcepts bc = new BasicConcepts();
        bc.Display();
        bc.Sum44(23,22);
        Calculator calc = new Calculator();

        WriteLine("Add: " + calc.Add(10, 5));
        WriteLine("Sub: " + calc.Subtract(10, 5));
        WriteLine("Mul: " + calc.Multiply(10, 5));
        WriteLine("Div: " + calc.Divide(10, 5));

        //Generics



        Box<int> b1 = new Box<int>();
        b1.Value = 123;
        b1.Value = 2345;
        Box<string> b2 = new Box<string>() ;
        b2.Value = "Hello";
        b2.Value = "Vishal";  
        
        WriteLine(b1.Value);
        WriteLine(b2.Value);

        int x22 = 10;
        int y22 = 20;

        Box<int> box = new Box<int>();
       WriteLine("Before: " + x22 + " " + y22);
        box.swap4(ref x22, ref y22);
        WriteLine("After: " + x22 + " " + y22);

        Pair<string, int> pair = new Pair<string, int>();
        pair.First= "Vishal";
        pair.Second = 23;
        pair.Display22();

        Store<int>  sr= new Store<int>();
        sr.Add22(10);

        //WriteLine(sr.Get());

        UserInput1.GetUserInput();

        DirectoryInfo ss1= new DirectoryInfo(@"D:\\DotNetLearningAllfiles\\CreatorVishal\\DotNetLearning\\Basics\\subfolderr");
        ss1.Create();

        //FileInfo f1 = new FileInfo("Ok.txt");

        //WriteLine("File Length: " + f1.Length);
        //WriteLine("File Full Name: " + f1.FullName);
        //WriteLine("File Exists: " + f1.Exists);


        //WriteLine("---------------------------------------------------------------------------------");
        //AllConceptspractice acp = new AllConceptspractice();
        //acp.TakeandMultiply(0, 0);
        //WriteLine("---------------------------------------------------------------------------------");
        //ListPractice lp = new ListPractice();
        //lp.ListExample();

        //WriteLine("---------------------------------------");
        //StudenT st=new StudenT();
        //st.Name22 = "Vishal";
        //st.Age22 = 23;
        //st.Display();
        //st.setData("Vishal Sharma", 22);
        //st.Display();

        //Dog1 dg1 = new Dog1();
        //dg1.Sound();
        //dg1.Bark();

        //loadingConcept lc = new loadingConcept();
        //lc.Multiply(2, 3);
        //lc.Multiply(3, 4, 3);


        //Animal3 an = new Dog3();
        //an.Sound();
        ////Circle3 cle = new Circle3();
        ////cle.Draw();
        //Shape cle = new Circle3();
        //cle.Draw();


        //Vehicle v = new Car2();
        //Vehicle v2 = new Bike();
        //v2.Start();
        //v2.Stop();
        //v.Start();
        //v.Stop();

        //IAnimal a = new Dog4();
        //a.sound();



        //Human h1 = new Human();
        //h1.Eat();
        //h1.Run1();

        practicefiles pv = new practicefiles();
        pv.createFiles1();
        WriteLine("------------------------------------");
        //FileManagementPracticeagain fp = new FileManagementPracticeagain();
        //fp.CreateFile();
        WriteLine("------------------------------");
        //CompressDecompress cd = new CompressDecompress();
        //cd.Compress_Decom();
        ////cd.ziprac();
        //cd.GzipPract();
        //cd.zpFile();
        //cd.Zarc();
        WriteLine("--------------------------");
        //cd.BrotliPrac();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // pretty JSON
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Name → name
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // null ignore
            //PropertyNameCaseInsensitive = true, // deserialization me flexible
            IncludeFields = true // fields bhi include (yaha needed nahi but demo ke liye)
        };

        Serialization_Deserialization sd = new Serialization_Deserialization { age = 23, name = "Vishal sharma" };
        string json = JsonSerializer.Serialize(sd, options);
            WriteLine(json);

        Serialization_Deserialization objj= JsonSerializer.Deserialize <Serialization_Deserialization > (json);
        WriteLine(objj.name);




        List<Serialization_Deserialization> list = new List<Serialization_Deserialization>
        {
            new Serialization_Deserialization{age=40,name="Rana" },
            new Serialization_Deserialization{age=44,name="Rana Kumar" }

        };
        string json2 = JsonSerializer.Serialize(list);
        WriteLine(json2);

        var dataa = JsonSerializer.Deserialize<List<Serialization_Deserialization>>(json2);
        if (dataa != null)
        {
            WriteLine(dataa[0].name);
        }

        var options1 = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
        };
        Student11 sk1 = new Student11 { Name = "Vishal sharma", Age = 23, Course = "MCA" };
        string jsonf = JsonSerializer.Serialize(sk1,options1);

        WriteLine(jsonf);
        //created file (file me save kr diya )
        File.WriteAllText("jsonprac.json", jsonf);

        //read 
        string datajson = File.ReadAllText("jsonprac.json");

        //deserialize
        var objj1 = JsonSerializer.Deserialize<Student11>(datajson, options1);
        if (objj1 != null)
        {
            WriteLine(objj1.Name);
            WriteLine(objj1.Age);
        }



        //var des = JsonSerializer.Deserialize<Student11>(jsonf,options1);
        //WriteLine("------------------");
        //if (des != null)
        //{
        //    WriteLine(des.Age);
        //}

        GenricPractice dr = new GenricPractice();
        NonGenericCollectionPractice cp = new NonGenericCollectionPractice();
        GenericCollectionPractice Gp = new GenericCollectionPractice();
        WriteLine("----------------------------------------");

        LinqPractice lp = new LinqPractice();



    }
}


     