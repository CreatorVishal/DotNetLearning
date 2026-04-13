

namespace Basics
{

    //namespace Basics.OOPS
    //{
    //    internal class GenericTesting<T, T2>
    //    {

    //        internal int Add(int a, int b)
    //        {
    //            return a + b;
    //        } //Normal method with normal parameters
    //        internal void Add2<V, V2>(V a, V2 b)
    //        {
    //            //a = 10
    //            WriteLine(a + " " + b);
    //        }
    //        internal void Add3(T A, T B)
    //        {
    //            WriteLine("Set return type using class generic T " + A + " " + B);
    //        }

    //        public T[] arr = new T[10];

    //        public int index = 0;
    //        public void InsertItem(T item)
    //        {
    //            if (index != arr.Length)
    //            {
    //                arr[index++] = item;
    //            }
    //        }

    //        public void DispArray()
    //        {
    //            foreach (T value in arr)
    //            {
    //                if (!(value != null && value.Equals(0)))
    //                {
    //                    Write(value + " ");
    //                }
    //            }
    //            WriteLine();
    //        }
    //    }


    //    internal class GenVishalTest
    //    {
    //        internal GenVishalTest()
    //        {
    //            GenericTesting<int, string> GenOBj = new GenericTesting<int, string>();
    //            GenOBj.Add2<int, string>(10, "Vishal Don");
    //            GenOBj.Add2<string, string>("second", "Vishal Don");
    //            GenOBj.Add3(10, 20);
    //            GenOBj.InsertItem(10);
    //            GenOBj.InsertItem(20);
    //            GenOBj.InsertItem(30);
    //            GenOBj.InsertItem(40);
    //            GenOBj.InsertItem(50);
    //            GenOBj.InsertItem(60);
    //            GenOBj.InsertItem(70);
    //            GenOBj.DispArray();
    //        }
    //    }
    //}
    internal class Generics<T>{
        internal void  Run <T,T2>(T a,T2 b){
            WriteLine($"Running with {a} and {b}");
        }
        

         
    }

}
