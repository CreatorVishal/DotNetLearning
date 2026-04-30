
using System.Collections;

namespace Basics
{
    internal class NonGenericCollectionPractice
    {

        public NonGenericCollectionPractice()
        {
            //ArrayList & it's Method
            ArrayList list = new ArrayList() { 2, 5, 99 };  
            list.Add(22);
            list.Add(233);
            list.Add("Vishal");
            list.Add(22.33);
            list.Add(true);
            foreach(var i in list)
            {
                Write(" "+i+" ");
            }
            //Remove by value 
            list.Remove(99);
            WriteLine("[After Removing 99]");
            foreach (var i in list)
            {
                Write(" " + i + " ");
            }
            //Remove item by index
            list.RemoveAt(0);
            //insert
            list.Insert(2, 1000);
            WriteLine();


            foreach (var i in list)
            {
                Write(" " + i + " ");

            }
            WriteLine(list.Contains("Vishal"));
            WriteLine();
            WriteLine(list.IndexOf("Vishal"));
            WriteLine();


            WriteLine("Total Items : " + list.Count);
            WriteLine();


            foreach (var i in list)
            {
                Write(" " + i + " ");

            }


            list.Reverse();
            WriteLine();


            foreach (var i in list)
            {
                Write(" " + i + " ");

            }

            list.Clear();
            WriteLine("After clear: " + list.Count);

            ArrayList extra = new ArrayList() { 200,300,400,500,600,700,800};
            list.AddRange(extra);
            foreach (var i in list)
            {
                Write(" " + i + " ");

            }

            //agr extra wala kisi or index se start krna ho to 
            list.InsertRange(1, extra);
            WriteLine("\nAfter InsertRange:");
            foreach (var i in list)
            {
                Write(" " + i);
               

            }
            WriteLine();

            //Remove range - ek sath bhot item delete krne ho to list.RemoveRange(0, 3) isme o se 3 tk item delete honge ;

            list.RemoveRange(0, 3);
            foreach (var i in list)
            {
                Write(" " + i);
               
            }
            WriteLine();
            //agr isme direct lgayega to crash hoga
            //list.Sort();

            ArrayList nums = new ArrayList() { 5, 2, 9, 1 };

            nums.Sort();

            foreach (var i in nums)
            {
                Console.Write(i + " ");
            }
            Write("-----------------------------------");

            //HashTable
            Hashtable ht = new Hashtable();

            ht.Add("name", "Vishal");
            ht.Add(1, 100);
            ht.Add(2, "Ok");

            WriteLine(ht["name"]);
            WriteLine(ht[1]);
            WriteLine(ht[2]);

            // Correct Remove
            ht.Remove(1);

            // Clear & re-add
            ht.Clear();

            ht.Add("name", "Vishal");
            ht.Add(1, 100);
            ht.Add(2, "Ok");
            ht.Add("age", 23);

            // Proper loop
            foreach (DictionaryEntry item in ht)
            {
                WriteLine(item.Key + " : " + item.Value);
            }

            // Contains
            WriteLine(ht.ContainsKey("age"));
            WriteLine(ht.ContainsValue(23));

            // Count
            WriteLine("Count: " + ht.Count);

            // Keys
            WriteLine("Keys:");
            foreach (var key in ht.Keys)
            {
                Write(key + " ");
            }

            // Values
            WriteLine("\nValues:");
            foreach (var val in ht.Values)
            {
                Write(val + " ");
            }
            WriteLine("----------------------------------------------");

            //----------STACK------------------
            Stack stk = new Stack();
            stk.Push(230);
            stk.Push(220);
            stk.Push(210);
            stk.Push(2);
            stk.Push(30);
            stk.Push(20);
            void Print(Stack s)
            {
                foreach (var i in s)
                    Write(i + " ");
                WriteLine();
            }
            Print(stk);
            if (stk.Count > 0)
            {
                stk.Pop();
            }
            Print(stk);
            if (stk.Count > 0)
            {
                stk.Pop();
            }
            WriteLine(stk.Peek());

            WriteLine(stk.Contains(230));

            //stk.Clear();
            //WriteLine("After Clear: " + stk.Count);
            //stack ko array me convert 
            Object[] arr = stk.ToArray();
            foreach (var i in arr)
            {
                WriteLine(i+" ");
            }

            Stack copy = (Stack)stk.Clone();
            Print(copy);
            WriteLine("-------------------------------");

            //--------------Queue---------------------------
            Queue q = new Queue();
            
            q.Enqueue(20);
            q.Enqueue("Vishal");
            q.Enqueue(23);
            q.Enqueue(44);
            q.Enqueue(66);
            q.Enqueue(33.4);
            q.Enqueue(true);
            void Print_Q(Queue q)
            {
                foreach (var i in q)
                    Write(i + " ");
                WriteLine();
            }
            Print_Q(q);
            var removed = q.Dequeue();
            WriteLine("Removed: " + removed);
            WriteLine("Front : " + q.Peek());
            WriteLine("Count : " + q.Count);

            Queue copy1 = (Queue)q.Clone();
            WriteLine("Copy : ");
            Print_Q(copy1);

            //Contains

            WriteLine(q.Contains(44));

            //Queue to array krna ho to 

            object[] arr3 = q.ToArray();
            WriteLine("Array:");
            foreach (var i in arr3)
            {
                Write(i + " ");
            }











        }


    }
    public class GenericCollectionPractice
    {
        public GenericCollectionPractice()
        {
            List<int> list1 = new List<int>();
            list1.Add(10);
            list1.Add(20);
            list1.Add(10);
            list1.Add(20);
            list1.Add(10);
            list1.Add(20);
            list1.Add(10);
            list1.Add(20);
            //list1.Add("Rahul"); Yha error aayega qki int hi de skte or kuch nhi 
            void Print2(List<int> list1)
            {
                foreach (var i in list1)
                {
                    Write(i+" ");
                }
                WriteLine();
            }
            Print2(list1);
            WriteLine("-------------------------");
            list1.Remove(20);
            Print2(list1);

            //Index se remove krna ho to 
            list1.RemoveAt(0);
            list1.RemoveAll(x => x == 20);// saare 20 hta dega  
            Print2(list1);

            List<int> extra = new List<int>() { 100, 200, 300, 400, 500 };
            list1.InsertRange(1, extra);
            Print2(list1);
            //insert
            list1.Insert(0, 999);
            Print2(list1);
            WriteLine("-----------------------");

            

            WriteLine("Contains 10: " + list1.Contains(10));
            WriteLine("Index of 10: " + list1.IndexOf(10));

            //sort
            list1.Sort();
            Print2(list1);
            //Reverse
            list1.Reverse();
            Print2(list1);
            WriteLine("----------------------------------");

            //Find
            var res = list1.Find(x => x > 100);
            WriteLine("First >100: " + res);

            //FindAll
            var res2 = list1.FindAll(x => x > 100);
            Print2(res2);

            //Count
            WriteLine("Count : " + list1.Count);

            //List to array
            int[] arr = list1.ToArray();

            foreach (var i in arr)
            {
                Write(i + " ");
            }
            WriteLine();
            //Clear
            //list1.Clear();
            //WriteLine("After Clear: " + list1.Count);
            WriteLine("--------------------------------");


            //------------Dictionary Generic----------------
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(0, "Vishal");
            dict.Add(1, "Montu");
            dict.Add(2, "Sunny");
            dict.Add(3, "Parshant");
            dict.Add(4, "Deepika");
            dict.Add(5, "Khushi");
            dict.Add(6, "Priya");
            dict.Add(7, "Divya");
            dict.Add(8, "Rahul");

            foreach(var item in dict)
            {
                Write(item.Key + " : " + item.Value);
                //WriteLine(item);
            }
            WriteLine();


            foreach (var key in dict.Keys)
                Console.WriteLine(key);

            foreach (var val in dict.Values)
                Console.WriteLine(val);
            WriteLine("-------------------------------");
            WriteLine(dict[2]);//get

            dict[2] = "RamLal";//update

            dict.Remove(8);

            //contains
            WriteLine(dict.ContainsKey(3));
            WriteLine(dict.ContainsValue("Vishal"));

            //Count
            WriteLine("Total: " + dict.Count);

            //TryGetvalue
            string val2;
            if (dict.TryGetValue(4, out val2))
            {
                WriteLine("Found: " + val2);
            }
          
            if (dict.ContainsKey(10))
            {
                WriteLine(dict[10]);
            }
            //Clear 
            //dict.Clear();
            //WriteLine("After Clear: " + dict.Count);
            //condition loop 
            foreach (var item in dict)
            {
                if (item.Key % 2 == 0)
                    WriteLine(item.Key + " : " + item.Value);
            }

        }
    }
}
