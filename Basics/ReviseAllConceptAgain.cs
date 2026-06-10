using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    //enum
    public enum EmployeeStatus
    {
        Active,
        Inactive,
        OnLeave
    }
    //Struct
    public struct Student1
    {
        public int Id;
        public string Name;
    }
    internal class RACA
    {
        //Phase 1 
        // Variables → Declaration, Initialization, Scope, Lifetime
        // Data Types → Value, Reference, Primitive, Nullable
        // Type Conversion → Implicit, Explicit, Convert, Parse, TryParse
        // Operators → Arithmetic, Relational, Logical, Assignment, Ternary, Null Coalescing
        // Input/Output → Input, Output, Formatting, Interpolation
        // Conditions → if, if-else, nested if, switch, switch expressions
        // Loops → for, while, do-while, foreach, break, continue
        // Arrays → Single, Multi, Jagged
        // Exception Handling → try, catch, finally, throw, custom exception

        public int age1; //Declaration -> field level variable -> default value 0
        public int age2 = 25;//Initialization


        public void Test()
        {
            int a = 23;//Local variable 
        }
        //--------------------------------------------------------------------------------------
        //Data Types
        //1.Value Type -->Actual value store krte h 
        //int,long,float,double,decimal,char,bool
        //2.Reference Type -->Actual value ka reference store krte h
        //string , object ,array,class,interface,delegate
        //3.Primitive Type -->Directly support krte h by c# compiler
        //int , long , short , byte , float , double , decimal , char , bool

        //------------------------------------------
        //Operators
        //Arithmetic Operator,Relational Operator,Logical Operator,Assignment Operator,Ternary Operator,Null Coalescing Operator


        public RACA()
        {
            //Variables and Scope
            int x = 5;
            if (x > 0)
            {
                int y = 10;

                Console.WriteLine(x);
                Console.WriteLine(y);
            }
            Console.WriteLine(x); //O/P--> 5 10 5
            //------------------------------------------------------
            int x1 = 10;
            int y1 = x1;

            y1 = 20;
            Console.WriteLine(x1);
            Console.WriteLine(y1);
            //-------------------------------------------
            //Type Conversion

            //Implicit Casting

            int num = 100;

            long data = num;

            Console.WriteLine(data);

            //Explicit Casting

            double price = 99.99;

            int amount = (int)price;

            Console.WriteLine(amount);


            //-------------------------------------
            string age = "45";
            bool success = int.TryParse(age, out int result);
            WriteLine(success);
            WriteLine(result);

            //out
            int a = 56;
            int b = 34;
            int c = 455;
            void Calculate(int x, int y, out int sum, out int product)
            {
                sum = x + y;
                product = x * y;
            }
            int total;
            int multiply;
            Calculate(a, b, out total, out multiply);
            WriteLine(total);
            WriteLine(multiply);
            //--------------------------------
            //Arithmetic 
            int a1 = 20;
            int b1 = 3;

            Console.WriteLine(a1 / b1);
            Console.WriteLine(a1 % b1);
            //-------------------------------------------
            //Null Coalescing Operator
            string str1 = null;
            string result1 = str1 ?? "RichUser";
            WriteLine(result1);

            // Exception Handling

            try
            {
                int num1 = 10;
                int num2 = 0;

                Console.WriteLine(num1 / num2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }



        }
    }
    public class Level2
    {
        public Level2()
        {
            Welcome();
            Welcome2("Vishal Sharma from Rohtak");
            int AgeRes = GetAge();
            WriteLine(AgeRes);

            int myAge = 24;

            ChangeAge(myAge);

            WriteLine(myAge);
            int Value = 34;
            DoubleNumber(ref Value);
            WriteLine(Value);

            DisplayUser("Vishal");

            WriteLine(Add(10, 20));

            WriteLine(Add(10, 20, 30));

            WriteLine(Add(10.5, 20.5));
            WriteLine(Sum1(10, 20, 30, 40, 50));
            WriteLine(Square(5));
            WriteLine(Fact(5));
            //----------------
            EmployeeStatus status = EmployeeStatus.Active;
            WriteLine((int)EmployeeStatus.Inactive);
            WriteLine(status);

            Student1 s1 = new();

            s1.Id = 1;
            s1.Name = "Vishal";

            WriteLine(s1.Id);
            WriteLine(s1.Name);

        }
        public void Welcome()
        {
            WriteLine("Hello Vishal sharma");

        }
        public int GetAge()
        {
            return 24;
        }
        //Method with parameter
        public void Welcome2(string name)
        {
            //WriteLine("Welcome "+ name);
            WriteLine($"Welcome {name}");
        }
        public void ChangeAge(int age)
        {
            age = 100;
        }

        public void DoubleNumber(ref int Number)
        {
            Number = Number * 2;

        }
        //Optional Parameter 
        public void DisplayUser(string name, int age = 18)
        {
            WriteLine($"Name : {name}");
            WriteLine($"Age : {age}");
        }
        //Method Overloading
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
        //params
        public int Sum1(params int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;

        }
        //Expression Bodied Method
        public int Square(int n) => n * n;
        //Recursion
        public int Fact(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Fact(n - 1);
        }
    }
    public class OOPMastery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Static constructor 
        static OOPMastery()
        {
            WriteLine("Static Constructor Called");
        }
        //Constructor Overloading 
        public OOPMastery() : this("Yogita Tomar")
        {
            WriteLine("Default Constructor");
        }
        //parameterised constructor
        public OOPMastery(string Name) : this(1, "Rahul KGF")
        {

            this.Name = Name;
            WriteLine("One parameter");

        }
        //-------------------------

        public OOPMastery(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            WriteLine("Two parameter");
        }




    }
    //Encapsulation
    public class EmployeeEnc
    {
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;

                }
            }

        }
    }
    // Base Class
    public class CompanyMember
    {
        public string Name = "Vishal";

        public CompanyMember()
        {
            WriteLine("CompanyMember Constructor");
        }

        public void Login()
        {
            WriteLine("Login Access");
        }
    }

    // Single Inheritance
    public class SoftwareEngineer : CompanyMember
    {
        public SoftwareEngineer()
        {
            WriteLine("SoftwareEngineer Constructor");
        }

        public void Code()
        {
            WriteLine("Writing C# Code");
        }
    }

    // Multilevel Inheritance
    public class TeamLead : SoftwareEngineer
    {
        public TeamLead()
        {
            WriteLine("TeamLead Constructor");
        }

        public void ManageTeam()
        {
            WriteLine("Managing Team");
        }
    }

    // Hierarchical Inheritance
    public class HRManager : CompanyMember
    {
        public void HireEmployee()
        {
            WriteLine("Hiring Employee");
        }
    }

    public class CyberSecurityAnalyst : CompanyMember
    {
        public void MonitorThreats()
        {
            WriteLine("Monitoring Security Threats");
        }
    }

    public class Animall1
    {
        public void Sound()
        {
            WriteLine("Animal");
        }
    }

    public class Dogg1 : Animall1
    {
        public new void Sound()
        {
            WriteLine("Dog");
        }
    }
    //Run time polymorphism 
    public class Animall2
    {
        public virtual void Sound2()
        {
            WriteLine("Animal Sound");
        }
    }

    public class Dog216 : Animall2
    {
        public override void Sound2()
        {
            WriteLine("Dog Bark");
        }
    }

    //Abstraction 
    public abstract class EmployeeAbs
    {
        public abstract void Work();
        public void login()
        {
            WriteLine("Employee Login");
        }
    }
    class DeveloperAbs : EmployeeAbs
    {
        public override void Work()
        {
            WriteLine("Developer is coding");
        }
    }

    //Interface 
    public interface IEmployee
    {
        void Work();
        void AttendMeeting();
    }
    public interface IStudent
    {
        void study();
    }
    class Manager : IEmployee, IStudent

    {
        public void Work()
        {
            WriteLine("Working");
        }

        public void AttendMeeting()
        {
            WriteLine("Attending Meeting");
        }
        public void study()
        {
            WriteLine("Studying");
        }
    }
    //Sealed Class --> Inheritance ko rokne ke liye use krte h
    //public sealed class Icapsule
    //{
    //    int id = 3;
    //    string name = "Rohan Das ";
    //    public void Display()
    //    {
    //        WriteLine($"ID : {id}");
    //        WriteLine($"Name : {name}");
    //    }

    //}

    //--------------------Static class-------------
    public static class Calculator1
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

    }
    //---------------------------------
    // ================= FILE 1 =================

    //public partial class EmployeeManager
    //{
    //    // Partial Method Declaration
    //    partial void BeforeAddEmployee();

    //    public void AddEmployee()
    //    {
    //        BeforeAddEmployee();

    //        WriteLine("Employee Added Successfully");
    //    }
    //}

    // ================= FILE 2 =================

    //public partial class EmployeeManager
    //{
    //    // Partial Method Implementation
    //    partial void BeforeAddEmployee()
    //    {
    //        WriteLine("Validation Completed");
    //    }
    //}
    //Nested class 
    public class University
    {
        public string UniversityName = "MDU";

        public class Student
        {
            public void Display()
            {
                WriteLine("Student Details");
            }
        }
    }
    //------------LEVEL4----------
    //Property
    public class Employeee
    {
        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }
    }
    //Auto property
    public class Student_Info
    {
        public int id { get; set; }
        public int age { get; set; }
        public string name { get; set; }
    }
    //Read only property -isko sirf get krne ke liye use krte h set nhi kr skte like company cc1.CompanyName="Google"; ye nhi kr skte h 
    public class Company
    {
        public string CompanyName
        {
            get
            {
                return "Microsoft";
            }
        }
    }
    //Init Property-Sirf object time pr hi value set kr skte h 
    public class Data
    {
        public string Name { get; init; }
    }
    //Collection Initializer->Line 1175 program.cs me dekho

    //INDEXER

    //var-->done

    //------------------------
    //Only for Revision
    //Anonymous Type
    //var stu = new
    //{
    //    name = "Naresh Raja",
    //    Roll_no = 23,
    //    age = 45

    //};
    //   WriteLine(stu.name);
    //   WriteLine(stu.Roll_no);
    //   WriteLine(stu.age);
    //---------------------------
    //Extension Method
    public static class Helper
    {
        public static void Greet(this string name)
        {
            WriteLine($"Hello {name}");
        }
    }
    //Record
    public record drama
    {
        public int id { get; set; }
        public int age { get; set; }
    }
    public delegate void MyDelegate();
   
    public class Level5
    {
        //---------------------------DELEGATES----------
        //step-1 Delegate
       
        //step2- Method
        public void Show()
        {
            WriteLine("Showing Something...");
        }

       
    }
    //------------MultiCast Delegate--------
    public delegate void multiDelegates();
    public delegate void delee();

    public class MCDel
    {
        public void show1() {
            WriteLine("Showing 1....");

        }
        public void show2()
        {
            WriteLine("Showing 2....");

        }
        public void show3()
        {
            WriteLine("Showing 3....");

        }
    }
    //-----------Anonymous method----> done

    //Action 
    public class Ac
    {
        public void ShowMe()
        {
            WriteLine("Showing..............");

        }
        //Action with one parameter 
        public void Welcome(string name)
        {
            WriteLine($"Welcome {name}");
        }
        //With multiple parameter
        public void Details(string name, int age)
        {
            WriteLine($"{name} {age}");
        }
    }

    //Func
    public class FuncDel
    {
        public int Add(int a , int b)
        {
            return a + b;
        } 
    }

    //Predicate
    public class PFunc
    {
        public bool IsAdult(int age)
        {
            return age >= 18;
        }
    }
    //Event 
    public class JioMobile
    {
        public event Action BatteryFull;
        public void ChargeBattery()
        {
            WriteLine("Battery Charging...");
            WriteLine("Battery 100%");
            BatteryFull?.Invoke();
        }
    }

    //------------------------------------------------------------------
    //Generics
    public class Container1<T>
    {
        public T Value;
    }
    //---------------------

    // Generic Class
    public class StorageBox<T>
    {
        public T Data;
    }

    // Normal Class
    public class LaptopInfo
    {
        public int Id;
        public string Brand;

    }

    //----------------------------
    //Generic method
    public class DataPrinter
    {
        public void PrintData<T>(T Value)
        {
            WriteLine(Value);
        }
    }
    //Generic interface 

    //step1
    public interface IDataStore<T>
    {
        public void Save(T item);
    }
    //step2--> ek bnayi student class 
    public class StudentData
    {
        public int Id;
        public string Name;
    }
    //step3-- ek bnayi teacher class 
    public class TeacherData
    {
        public int Id;
        public string Name;
    }
    //step4 ------>Student repo
    public class StudentStore : IDataStore<StudentData>
    {
        public void Save(StudentData item)
        {
            WriteLine($"Student Saved : {item.Name}");
        }

    }
    //step5
    public class TeacherStore : IDataStore<TeacherData>
    {
        public void Save(TeacherData item)
        {
            WriteLine($"Teacher Saved : {item.Name} ");
        }
    }

    //------------------------------------
    //Generic constraints
    // Normal Class
    public class StudentRecord
    {
        public int Id;
        public string Name;
    }

    // Generic Class with Constraint
    public class DataManager<T> where T : class
    {
        public void Save(T item)
        {
            WriteLine("Data Saved Successfully");
        }
    }

}
   