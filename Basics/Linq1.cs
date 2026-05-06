
namespace Basics
{
    internal class Linq1
    {
        public Linq1()
        {
            List<int> list = new List<int>() { 11, 21, 32, 4, 5, 0, 99, 88, 7, 6, 5 };
            //var evenNumbers = list.Where(x => x % 2 == 0);
            //var oddNumbers = list.Where(x => x % 2 != 0);
            //WriteLine("Even numbers:");
            var resGreator = list.Where(x => x > 40);
            foreach (var num in resGreator)
            {
                Write(num + " ");
            }
            WriteLine();
            //Double every number in the list which is greater than 10
            var doubledGreaterThan10 = list.Where(x => x > 10).Select(x => x * 2);
            WriteLine("Doubled numbers greater than 10:");
            foreach (var num in doubledGreaterThan10)
            {
                Write(num + " ");
            }
            WriteLine();

            List<Student123> lt123 = new List<Student123>()
            {
                new Student123 { age = 28, name = "Rohit", city = "Rohtak", salary = 30000, id = 1 },
                new Student123 { age = 30, name = "Amit", city = "Delhi", salary = 35000, id = 2 },
                new Student123{ age = 25, name = "Suman", city = "Mumbai", salary = 25000, id = 3 },
                new Student123{ age = 32, name = "Priya", city = "Bangalore", salary = 40000, id = 4 },
                new Student123{ age = 27, name = "Anil", city = "Chennai", salary = 28000, id = 5 },
                new Student123{ age = 29, name = "Neha", city = "Hyderabad", salary = 32000, id = 6 },
                new Student123{ age = 31, name = "Vikram", city = "Delhi", salary = 38000, id = 7 },
                new Student123{ age = 26, name = "Sonia", city = "Ahmedabad", salary = 27000, id = 8 },
                new Student123{ age = 33, name = "Rahul", city = "Jaipur", salary = 42000, id = 9 },
                new Student123{ age = 24, name = "Kavita", city = "Lucknow", salary = 24000, id = 10 }
            };
            //Find Delhi students
            var FindDelhiStudents = lt123.Where(s => s.city == "Delhi");
            foreach (var student in FindDelhiStudents)
            {
                WriteLine($"Name: {student.name}, Age: {student.age}, Salary: {student.salary}");
            }
            //Salary>30000
            var SalaryMore = lt123.Where(s => s.salary > 30000);
            foreach (var student in SalaryMore)
            {
                WriteLine($"Name: {student.name}, Salary: {student.salary}");

            }
            //Age>30
            var MoreAge = lt123.Where(s => s.age > 30);
            foreach (var student in MoreAge)
            {
                WriteLine($"Name: {student.name}, Age: {student.age}");
            }
            WriteLine();

            //Only Name 
            var OnlyName = lt123.Select(x => x.name);
            foreach (var name in OnlyName)
            {
                Write($"Name: {name}");
            }
            WriteLine();

            //Chaining
            var ChaingRes = lt123.Where(x => x.salary > 30000).Select(x => x.city == "Delhi").OrderBy(x => x);
            foreach(var item in ChaingRes)
            {
                WriteLine(" " + item +" ");

            }


        }

        class Student123
        {
            public int age { get; set; }
            public string name { get; set; }
            public string city { get; set; }
            public double salary { get; set; }
            public int id { get; set;}

        }


    }

    }