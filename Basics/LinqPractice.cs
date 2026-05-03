using System.Linq;
using System.Reflection;
namespace Basics
{
    internal class LinqPractice
    {
        public LinqPractice()
        {

            //Where with only one condition 
            List<int> list = new List<int>() { 20, 10, 33, 55, 40, 60, 40, 33, 50 };
            var result = list.Where(x => x > 10);
            foreach (var item in result)
            {
                Write(item + " ");
            }
            WriteLine();
            //Where with Multiple conditions
            var result2 = list.Where(x => x > 10 && x < 50);

            foreach (var item in result2)
            {
                Write(item + " ");
            }
            WriteLine();

            //Select(Transform)
            var res = list.Select(x => x * 2);
            foreach (var item in res)
            {
                Write(item + " ");
            }
            WriteLine();

            //Chaining
            var chainres = list.Where(x => x > 10)
                .Select(x => x * 10);
            foreach (var item in chainres)
            {
                Write(item + " ");
            }
            WriteLine("----------------------------Practice ---------------------------------");


            var res1 = list.Where(x => x < 50);
            foreach (var item in res1)
            {
                Write(item + " ");
            }
            WriteLine();

            var res2 = list.Select(x => x + 7);
            foreach (var item in res2)
            {
                Write(item + " ");
            }
            WriteLine();
            var res3 = list.Where(x => x > 20).Select(x => x * 3);
            foreach (var item in res3)
            {
                Write(item + " ");
            }
            WriteLine("-------------------------------------------------------------");

            //OrderBy
            var ResultinAsc = list.OrderBy(x => x);
            foreach (var item in ResultinAsc)
            {
                Write(item + " ");
            }

            WriteLine();
            //OrderByDescending

            var ResultinDesc = list.OrderByDescending(x => x);
            foreach (var item in ResultinDesc)
            {
                Write(item + " ");
            }
            WriteLine();
            //First - returns the first element that satisfies the condition
            //First error dega agr element na mila to is se safe h FirstorDefault use karna
            var res4 = list.First(x => x > 20);
            WriteLine(res4);

            //FirstOrDefault - returns the first element that satisfies the condition or default value if no such element is found
            var res6 = list.FirstOrDefault(x => x > 100);
            WriteLine(res6); //Output will be 0 as default value of int is 0    

            //Last- returns the last element that satisfies the condition
            var res5 = list.Last(x => x > 50);
            WriteLine(res5);
            WriteLine("---------------------");

            //Any- returns true if any element in the sequence satisfies the condition, otherwise false
            WriteLine(list.Any(x => x > 100));

            //All- it checks if all elements in the sequence satisfy the condition and returns true if they do, otherwise false
            WriteLine(list.All(x => x > 10));

            //Any- it checks if any element in the sequence satisfies the condition and returns true if at least one element does, otherwise false
            WriteLine(list.Any(x => x > 50));

            //Count- it counts the number of elements in the sequence that satisfy the condition and returns that count
            //WriteLine(list.Count(x => x > 20));
            WriteLine(list.Count(x => x % 2 == 0)); //Count of even numbers in the list

            //Distinct- it returns a new sequence that contains only distinct elements from the original sequence, eliminating duplicates
            var res7 = list.Distinct();
            foreach (var item in res7)
            {
                Write(item + " ");
            }
            WriteLine("-------------------------------");

            //Take or Skip

            var res8 = list.Take(5); //Takes the first 5 elements from the list
            foreach (var item in res8)
            {
                Write(item + " ");
            }
            WriteLine("----------------------------------------------------------");

            var res9 = list.Skip(3);
            foreach (var item in res9)
            {
                Write(item + " ");
            }
            WriteLine();
            WriteLine("-----");
            //Calculation on Numbers 
            WriteLine("Sum: " + list.Sum());
            WriteLine("Min: " + list.Min());
            WriteLine("Max: " + list.Max());
            WriteLine("Average: " + list.Average());

            //var resRev = System.Linq.Enumerable.Reverse(list).ToList(); //Reverses the order of the elements in the list
            //Mainly three ways to use Reverse in C#:
            //list.Reverse(); //In-place reversal of the list

            //foreach (var item in list)
            //{
            //    Write(item + " ");
            //}
            //WriteLine();

            //----------------------2nd Way-----------------------------
            //var resRev= list.AsEnumerable().Reverse(); //Reverses the order of the elements in the list without modifying the original list

            //foreach (var item in resRev)
            //{
            //    Write(item + " ");
            //}
            //WriteLine();

            //-----------------------------3rd Way-----------------------------
            //force linq
            // var resRev=System.Linq.Enumerable.Reverse(list).ToList(); //Reverses the order of the elements in the list without modifying the original list
            //foreach (var item in resRev)
            // {
            //     Write(item + " ");
            // }
            // WriteLine();

            List<RealWorldProblem> students = new List<RealWorldProblem>()
            {
                  new RealWorldProblem { Name = "Vishal", Marks = 80, Age = 22 },
                  new RealWorldProblem { Name = "Amit", Marks = 45, Age = 19 },
                  new RealWorldProblem { Name = "Rahul", Marks = 90, Age = 23 },
                  new RealWorldProblem { Name = "Neha", Marks = 60, Age = 21 },
                  new RealWorldProblem { Name = "Priya", Marks = 30, Age = 18 },
                  new RealWorldProblem { Name = "Deepika", Marks = 80, Age = 21 }
            };
            var ress = students.Where(x => x.Marks > 50 && x.Age > 20);
            foreach (var item in ress)
            {
                WriteLine(item.Name + " " + item.Marks);
            }
            WriteLine();

            var grp = students.GroupBy(x => x.Marks);
            foreach (var item in grp)
            {
                WriteLine("Marks --  " + item.Key);
                foreach (var student in item)
                {
                    WriteLine(student.Name + " " + student.Age);
                }

            }


            //Join

            List<Stu> dict1 = new List<Stu>()
                {
                    new Stu{ Id = 1, Names = "Vishal" },
                    new Stu { Id = 2, Names = "Amit" },
                    new Stu { Id = 3, Names = "Rahul" },
                    new Stu { Id = 4, Names = "Neha" },
                    new Stu { Id = 5, Names = "Priya" },
                    new Stu { Id = 6, Names = "Deepika" },
                    new Stu { Id = 7, Names = "Rohit" },


                };
            List<Course> dict2 = new List<Course>()
                    {
                        new Course { Id = 1, Name = "C#" },
                        new Course { Id = 2, Name = "Java" },
                        new Course { Id = 3, Name = "Python" },
                        new Course { Id = 4, Name = "JavaScript" },
                        new Course { Id = 5, Name = "C++" },
                        new Course { Id = 6, Name = "Ruby" },
                        new Course { Id = 8, Name = "Go" },
                    };
            WriteLine("----------------------------------------------");
            //var joiner = dict1.Join(dict2, s => s.Id, c => c.Id, (s, c) => new
            //{
            //    s.Names,
            //    c.Name
            //});

            //foreach (var item in joiner)
            //{
            //    WriteLine(item.Names + " -- " + item.Name);
            //}
          var  joiner= from s in dict1
                       join c in dict2
                       on s.Id equals c.Id
                       select new
                       {
                           s.Names,
                            c.Name
                       };
            foreach (var item in joiner)
            {
                WriteLine(item.Names + " -- " + item.Name);
            }

            WriteLine("------------------------------------------------------");

            //even number 
            var listEven = list.Where(x => x % 2 == 0);
            foreach (var item in listEven)
            {
                Write(item + " ");
            }
            WriteLine();
            //double the number in list
            var listDouble = list.Select(x => x * 2);
            foreach (var item in listDouble)
            {
                Write(item + " ");
            }
            WriteLine();

            //Filtering + Sorting
            var filterSort = list.Where(x => x > 50).OrderBy(x => x);
            foreach (var item in filterSort)
            {
                Write(item + " ");

            }
            WriteLine();

            WriteLine("Max value in list: " + list.Max());
            WriteLine("Min value in list: " + list.Min());
            WriteLine("---------------------------------------------");

            var resul = students.GroupBy(x => x.Marks);
            foreach (var item in resul)
            {
                WriteLine("Marks" + item.Key);
                foreach (var item2 in item)
                {
                    WriteLine(item2.Name);
                }
            }
            WriteLine("------------------------------------------------------");
            List<int> list4 = new List<int>() { 10,20,30,40,50,60,30,20,40};
            var resGrp = list4.GroupBy(x => x);
            foreach(var group in resGrp)
            {
                WriteLine("Number : " + group.Key);
                foreach(var item in group)
                {
                    Write(item + " ");
                }
                WriteLine();
            }
            WriteLine();
            //Query Syntax for Join

            var result12 =
                from s in dict1
                join c in dict2
                on s.Id equals c.Id
                select new
                {
                    s.Names,
                    c.Name
                };
            foreach(var item in result12)
            {
                WriteLine(item.Names + " -- " + item.Name);
            }
            WriteLine();
            //-----------------------------------------------------------
            var ress12 = dict1.Join(dict2,
                s => s.Id,
                c => c.Id,
                (s, c) => new
                {
                    s.Names,
                    c.Name
                }
                );
            foreach (var item in ress12)
            {
                WriteLine(item.Names + " -- " + item.Name);
            }
            WriteLine();
            //Level 1--Where, Select, OrderBy, Take, Skip

            List<int> list5 = new List<int>() { 10, 20,  60, 70, 30, 40, 50, 80, 90, 100 };
            //Where
            var resWhere = list5.Where(x => x > 50);
            foreach (var item in resWhere)
            {
                Write(item + " ");
            }
            //Select 
            var resSelect = list5.Select(x => x * 3);
            foreach (var item in resSelect)
            {
                Write(item + " ");
            }
            WriteLine();
            //OrderBy
            var resOrderBy = list5.OrderBy(x => x);
            foreach (var item in resOrderBy)
            {
                Write(item + " ");
            }
            WriteLine();

            //Take
            var resTake = list5.Take(5);
            foreach (var item in resTake) { 
                Write(item + " ");
            }
            WriteLine();

            //skip
            var resSkip = list5.Skip(5);
            foreach (var item in resSkip)
            {
                Write(item + " ");
            }
            WriteLine();

            //combo 
            var resCombo = list5.Where(x => x > 50).OrderBy(x => x).Take(3);
            foreach (var item in resCombo)
            {
                Write(item + " ");
            };
            WriteLine();

            //Level 2

            //ThenBy method is used to perform a secondary sorting operation on a sequence that has already been sorted using the OrderBy method. It allows you to specify an additional sorting criterion to further order the elements in the sequence when there are multiple elements with the same key in the primary sorting operation.
            var resThenBy = students.OrderBy(x => x.Marks).ThenBy(x => x.Age);
            foreach (var item in resThenBy)
            {
                WriteLine(item.Name + " " + item.Marks + " " + item.Age);
            }
            WriteLine();
            //ThenByDescending
            var resThenByDesc = students.OrderBy(x => x.Marks).ThenByDescending(x => x.Age);
            foreach (var item in resThenByDesc)
            {
                WriteLine(item.Name + " " + item.Marks + " " + item.Age);
            }
            WriteLine();




        }



        public class RealWorldProblem
        {
            public string Name;
            public int Age;
            public int Marks;

        }

        class Stu
        {
            public int Id;
            public string Names;
        }
        class Course
        {
            public int Id;
            public string Name;
        }
    }
}