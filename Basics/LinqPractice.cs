using System.Linq;
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
                  new RealWorldProblem { Name = "Priya", Marks = 30, Age = 18 }
            };
            var ress = students.Where(x => x.Marks > 50 && x.Age > 20);
            foreach(var item in ress)
            {
                WriteLine(item.Name+" "+item.Marks);
            }
            WriteLine();

        }

    }
    public class RealWorldProblem
    {
        public string Name;
        public int Age;
        public int Marks;

   }
}