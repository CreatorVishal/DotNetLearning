using System;
using System.Collections;
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
        public void show1()
        {
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
        public int Add(int a, int b)
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
    //Collection
    //-------------------------------Non Generic Collection---------------------------
    //1.ArrayList
    //2.HashTable
    //------ARRAYLIST
    public class ALPractice
    {
        public void ShowArrayList(ArrayList arr)
        {
            foreach (var item in arr)
            {
                WriteLine(item);
            }

            WriteLine("----------------");
        }
        public ALPractice()
        {
            ArrayList arrlist1 = new ArrayList();
            //Add()
            arrlist1.Add(45);
            arrlist1.Add("Rohit");
            arrlist1.Add(45.99);
            ShowArrayList(arrlist1);
            //AddRange()->ek sath multiple item add
            arrlist1.AddRange(new object[]
            {
                "Rahul",
                "Aman",
                 500
            });
            ShowArrayList(arrlist1);

            //Insert()-->specific position pr kuch add krna ho to 
            arrlist1.Insert(1, "Vishal Sharma from Rohtak");
            ShowArrayList(arrlist1);

            //InsertRange()
            arrlist1.InsertRange(1, new object[]
            {
                "Hi",
                "Hello",
                "Success"

            });
            ShowArrayList(arrlist1);
            //Remove & RemoveAt
            arrlist1.Remove("Hi");
            arrlist1.RemoveAt(1);
            ShowArrayList(arrlist1);

            //RemoveRange
            arrlist1.RemoveRange(1, 2);
            ShowArrayList(arrlist1);

            //Contains
            WriteLine(arrlist1.Contains(45));

            //indexof
            WriteLine(arrlist1.IndexOf(45));

            //Clear -->sb kuch clear kr dega

            //Count
            WriteLine(arrlist1.Count);

            //Sort
            ArrayList nums = new ArrayList();

            nums.Add(50);
            nums.Add(20);
            nums.Add(10);

            nums.Sort();
            ShowArrayList(nums);
            nums.Reverse();
            ShowArrayList(nums);

            //Clone
            ArrayList nums2 = (ArrayList)nums.Clone();
            ShowArrayList(nums2);

            //toarray
            object[] data1 = nums2.ToArray();
            foreach (var ob in nums2)
            {
                WriteLine(" " + ob + " ");
            }





        }
    }
    public class HTPractice
    {
        public HTPractice()
        {
            Hashtable ht = new Hashtable();

            ht.Add(101, "Vishal");
            ht.Add(102, "Rahul");
            ht.Add(103, "Aman");

            foreach (DictionaryEntry item in ht)
            {
                WriteLine($"{item.Key} : {item.Value}");
            }

            WriteLine("----------------");

            WriteLine(ht[101]);

            WriteLine(ht.ContainsKey(102));

            WriteLine(ht.ContainsValue("Aman"));

            WriteLine(ht.Count);

            ht.Remove(102);

            foreach (DictionaryEntry item in ht)
            {
                WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
    //--------------------------------Generic collection----------------------
    public class LPractice
    {
        public LPractice()
        {
            List<string> names = new List<string>();

            names.Add("Vishal");

            names.Add("Rahul");

            names.AddRange(new List<string>()
            {
                "Aman",
                "Rohit"
            });

            names.Insert(1, "Naresh");

            names.Remove("Aman");

            WriteLine(names.Contains("Rahul"));

            WriteLine(names.IndexOf("Rahul"));

            WriteLine(names.Count);

            names.Sort();

            names.Reverse();

            names.ForEach(x =>
            {
                WriteLine(x);
            });

            WriteLine("----------------");

            List<int> nums =
            new List<int>()
            {
                10,20,30,40,50
            };

            WriteLine(
            nums.Find(x => x > 25)
            );

            var allNums =
            nums.FindAll(x => x > 25);

            foreach (var item in allNums)
            {
                WriteLine(item);
            }

            WriteLine(
            nums.Exists(x => x > 40)
            );

            int[] arr =
            nums.ToArray();

            foreach (var item in arr)
            {
                WriteLine(item);
            }
        }

    }
    //Dictionary
    public class DPractice
    {
        public DPractice()
        {
            Dictionary<int, string> students =
new Dictionary<int, string>();

            students.Add(101, "Vishal");

            students.Add(102, "Rahul");

            students[103] = "Aman";

            WriteLine(students.Count);

            WriteLine(
            students.ContainsKey(101)
            );

            WriteLine(
            students.ContainsValue("Rahul")
            );

            if (students.TryGetValue(
            101,
            out string name))
            {
                WriteLine(name);
            }

            students[101] = "Vishal Sharma";

            foreach (var item in students)
            {
                WriteLine(
                $"{item.Key} : {item.Value}");
            }

            students.Remove(102);

            WriteLine("After Remove");

            foreach (var item in students)
            {
                WriteLine(
                $"{item.Key} : {item.Value}");
            }

            foreach (var key in students.Keys)
            {
                WriteLine(key);
            }

            foreach (var value in students.Values)
            {
                WriteLine(value);
            }
        }
    }
    //---------------QUEUE-------
    public class QPractice
    {
        public QPractice()
        {

            Queue<string> q =
            new Queue<string>();

            q.Enqueue("Vishal");

            q.Enqueue("Rahul");

            q.Enqueue("Aman");

            foreach (var item in q)
            {
                WriteLine(item);
            }

            WriteLine("---------");

            WriteLine(q.Peek());

            WriteLine("---------");

            WriteLine(q.Dequeue());

            WriteLine("---------");

            foreach (var item in q)
            {
                WriteLine(item);
            }

            WriteLine(q.Count);

            WriteLine(
            q.Contains("Rahul")
            );
        }

    }

    //Stack
    public class SPractice
    {
        public SPractice()
        {
            Stack<string> stq = new Stack<string>();
            stq.Push("Vishal");

            stq.Push("Rahul");

            stq.Push("Aman");
            //-----
            foreach (var item in stq)
            {
                WriteLine(item);
            }

            WriteLine("--------");

            WriteLine(stq.Peek());

            WriteLine("--------");

            WriteLine(stq.Pop());

            WriteLine("--------");

            foreach (var item in stq)
            {
                WriteLine(item);
            }

            WriteLine(stq.Count);

            WriteLine(
            stq.Contains("Rahul")
            );
        }


    }
    //HashSet
    public class HashSetPractice
    {
        public HashSetPractice()
        {
            HashSet<string> users =
            new HashSet<string>();

            users.Add("Vishal");

            users.Add("Rahul");

            users.Add("Vishal");

            foreach (var item in users)
            {
                WriteLine(item);
            }

            WriteLine("---------");

            WriteLine(
            users.Contains("Rahul")
            );

            WriteLine(users.Count);

            users.Remove("Rahul");

            WriteLine("---------");

            foreach (var item in users)
            {
                WriteLine(item);
            }

            HashSet<string> team1 =
            new HashSet<string>()
            {
            "Vishal",
            "Rahul"
            };

            HashSet<string> team2 =
            new HashSet<string>()
            {
            "Rahul",
            "Aman"
            };

            team1.UnionWith(team2);

            WriteLine("Union");

            foreach (var item in team1)
            {
                WriteLine(item);
            }
        }
    }

    //SortedList--->done
    //LinkedList--->done

    //---------------------------IENUMERABLE PRACTICE-------------------
    public class IEnumPractice
    {
        public IEnumPractice()
        {
            List<string> ls1 = new List<string>()
            {
                "Vishal",
                "Rahu Don",
                "Keshav"
            };
            IEnumerable<string> dt1 = ls1;
            foreach (var i in dt1)
            {
                WriteLine(" " + i + " ");
            }
            //dt1.Add("")------>error dega 
            //-----------------------------IENUMARATOR-------

            List<string> names =
        new List<string>()
        {
            "Vishal",
            "Rahul",
            "Aman"
        };

            IEnumerator<string> en =
            names.GetEnumerator();

            while (en.MoveNext())
            {
                WriteLine(en.Current);
            }

            en.Reset();

            WriteLine("After Reset");

            while (en.MoveNext())
            {
                WriteLine(en.Current);
            }
        }
        public IEnumerable<int> GetNumbers()
        {
            return new List<int>()
            {
                10,
                20,30,
                40,
            };
        }
        //----------------------------------------------------------------



    }
    //ICollection or IList
    public class InterfaceCollectionPractice
    {
        public InterfaceCollectionPractice()
        {
            ICollection<string> c1 =
            new List<string>();

            c1.Add("Vishal");
            c1.Add("Rahul");

            WriteLine(c1.Count);

            //--------------------------------

            IList<string> l1 =
            new List<string>();

            l1.Add("Vishal");
            l1.Add("Rahul");
            l1.Add("Aman");

            WriteLine(l1[0]);

            l1.Insert(1, "Keshav");

            l1.RemoveAt(0);

            foreach (var item in l1)
            {
                WriteLine(item);
            }
        }
    }
    //---------------------------------------------------
    //LINQ
    public class LPractice1
    {
        public void ShowData<T>(IEnumerable<T> data)
        {
            foreach (var item in data)
            {
                WriteLine(item);
            }

            WriteLine("------------");
        }
        public LPractice1()
        {

            //Where()
            List<int> ll1 = new List<int>()
            {
                10,20,30,10,10,20,70,40,50,60,70
            };
            var Result = ll1.Where(x => x > 25);

            ShowData(Result);
            //where+select 
            var Result1 = ll1.Where(x => x > 30).Select(x => x + 2);
            ShowData(Result1);

            //OrderBy
            var res2 = ll1.OrderBy(x => x);
            ShowData(res2);
            //orderBy descending
            var res3 = ll1.OrderByDescending(x => x);
            ShowData(res3);
            //First & FirstorDefault 

            //var res4 = ll1.First(x => x > 100);--Exception aayega 
            var res4 = ll1.First(x => x > 20);
            WriteLine(res4);

            //FirstorDefault--->agr na bhi mila to 0 return krega exception nhi dega 
            var res5 = ll1.FirstOrDefault(x => x > 100);
            WriteLine(res5);

            //-----------last & lastorDefault---->Done
            //Single & singleordefault
            //var res6 = ll1.Single(x => x == 20);
            //WriteLine(res6);

            //SingleOrDefault 
            var res7 = ll1.SingleOrDefault(x => x == 100);//0
            //var res7 = ll1.SingleOrDefault(x => x >20);-------------->isme exception dega 
            WriteLine(res7);

            //ANY
            var res8 = ll1.Any(x => x > 25);
            WriteLine(res8);

            //All 
            var res9 = ll1.All(x => x > 2);
            var res10 = ll1.All(x => x > 40);
            WriteLine(res9);
            WriteLine(res10);
            WriteLine(ll1.Count);
            //Aggregate
            WriteLine(ll1.Sum());

            WriteLine(ll1.Average());

            WriteLine(ll1.Min());
            WriteLine(ll1.Max());
            WriteLine("------------------------------------");
            var res11 = ll1.Take(3);
            foreach (var item in res11)
            {
                WriteLine(item);
            }
            WriteLine("------------------------------------");

            var res12 = ll1.Skip(3);
            foreach (var item in res12)
            {
                WriteLine(item);
            }
            //Distinct
            WriteLine("----------------------------------------");
            var res13 = ll1.Distinct();
            ShowData(res13);
            //Group by
            List<Employee> employees =
        new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Vishal",
                Department = "IT",
                Salary = 50000
            },

            new Employee()
            {
                Id = 2,
                Name = "Rahul",
                Department = "HR",
                Salary = 30000
            },

            new Employee()
            {
                Id = 3,
                Name = "Aman",
                Department = "IT",
                Salary = 60000
            },

            new Employee()
            {
                Id = 4,
                Name = "Rohit",
                Department = "HR",
                Salary = 35000
            },

            new Employee()
            {
                Id = 5,
                Name = "Keshav",
                Department = "IT",
                Salary = 70000
            }
        };

            var groups =
            employees.GroupBy(
            x => x.Department
            );

            foreach (var group in groups)
            {
                WriteLine(
                $"Department : {group.Key}"
                );

                foreach (var emp in group)
                {
                    WriteLine(
                    $"{emp.Name} - {emp.Salary}"
                    );
                }

                WriteLine("----------------");
                // ThenBy() --> Secondary Sorting
                // Example:
                // City same ho to Name ke hisab se sort karo

                // ThenByDescending() --> Secondary Descending Sorting

                // Contains() --> Check item exists or not

                // Distinct() --> Remove duplicate records

                // Union() --> Merge 2 collections and remove duplicates

                // Intersect() --> Common records between 2 collections

                // Except() --> Records in first collection but not in second

                // SelectMany() --> Flatten nested collections
                // Example:
                // List<List<int>> => List<int>

                // ToList() --> Convert LINQ result into List<T>

                // ToDictionary() --> Convert collection into Dictionary<TKey,TValue>

                // GroupBy() --> Group records by common property
                // Example:
                // Department wise employees

                // Join() --> Combine data from 2 collections
                // Similar to SQL Inner Join

                // Aggregate() --> Custom calculation on collection
                // Example:
                // Total sum using custom logic

                // OfType<T>() --> Filter only specific type objects

                // Cast<T>() --> Convert collection type

                // Zip() --> Combine 2 collections item by item

                // Chunk() --> Divide collection into small batches

                // ------------------------------------------------------------
            }
        }
        public class Employee
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Department { get; set; }

            public int Salary { get; set; }
        }

    }

}
