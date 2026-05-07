
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
            var ChaingRes = lt123
                .Where(x => x.salary > 30000 && x.city == "Delhi")
                .Select(x => x.name)
                .OrderBy(x => x);
            List<Employee> employees = new List<Employee>()
{
    new Employee{ Id=1, Name="Vishal", Department="IT", Salary=50000, Experience=2},
    new Employee{ Id=2, Name="Amit", Department="HR", Salary=30000, Experience=1},
    new Employee{ Id=3, Name="Rahul", Department="IT", Salary=70000, Experience=5},
    new Employee{ Id=4, Name="Neha", Department="Finance", Salary=60000, Experience=4},
    new Employee{ Id=5, Name="Priya", Department="IT", Salary=90000, Experience=7},
    new Employee{ Id=6, Name="Deepika", Department="HR", Salary=40000, Experience=2},
};
            var resEmp = employees.Where(x => x.Department == "IT");
            foreach(var emp in resEmp)
            {
                Write($"Name: {emp.Name}");
            }
            WriteLine();
            var resS= employees.Where(x=>x.Salary>50000).Select(x=>x.Name);
            foreach (var name in resS)
            {
                Write($"Name: {name}");
            }
            WriteLine();


            var resMutiple = employees.Where(x=>x.Experience>=3 && x.Salary>50000).Select(x=>x.Name);
            foreach(var name in resMutiple)
            {
                Write($"Name: {name}");
            }
            WriteLine("--------------------------------------------------------------------------");
            var resCont1 = employees.Where(x=>x.Name.ToLower().Contains("a")).Select(x=>x.Name);
            foreach (var item in resCont1)
            {
                Write(item);
            }
            WriteLine();
            //Question 1 Double the number which is greater than 10
            List<int> nums = new List<int>(){10,20,30,5,2,40};
            var resQ1 = nums.Where(x => x > 10).Select(x => x * 2);
            foreach(var item in resQ1)
            {
                WriteLine(item);
            }
            //Question 2 Even numbers nikalo aur ascending me sort karo
            var resQ2 = nums.Where(x => x % 2 == 0).OrderBy(x => x);
            foreach(var item in resQ2)
            {
                Write(item);
            }
            WriteLine();

            var resQ3 = employees.OrderBy(x=>x.Department).ThenByDescending(x=>x.Salary).Select(x=>x.Name);
            foreach(var item in resQ3)
            {
                Write(item);
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
        class Employee
        {
            public int Id;
            public string Name;
            public string Department;
            public int Salary;
            public int Experience;
        }
        class Student1234
        {
            public int Id;
            public string Name;
            public string Course;
            public int Marks;
            public int Age;
        }
        interface IStudentService
        {
            IEnumerable<Student1234> GetStudents();
        }
        class StudentService : IStudentService
        {
            public IEnumerable<Student1234> GetStudents()
            {
                return new List<Student1234>()
        {
            new Student1234{ Id=1, Name="Vishal", Course="MCA", Marks=80, Age=22},
            new Student1234{ Id=2, Name="Amit", Course="BCA", Marks=60, Age=20},
            new Student1234{ Id=3, Name="Rahul", Course="MCA", Marks=90, Age=23},
            new Student1234{ Id=4, Name="Neha", Course="BTech", Marks=70, Age=21},
            new Student1234{ Id=5, Name="Priya", Course="MCA", Marks=95, Age=24},
            new Student1234{ Id=6, Name="Deepika",Course="BCA", Marks=50, Age=19},
            new Student1234{ Id=7, Name="Rohit", Course="BTech", Marks=85, Age=22}
        };
            }
        }

    }

    }