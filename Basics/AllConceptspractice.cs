

namespace Basics
{
    public class AllConceptspractice
    {

        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public void TakeandMultiply(int a , int b)
        {
            WriteLine("Enter first number:");
            int a1= Convert.ToInt32(Console.ReadLine());
            WriteLine("Enter second number:");
            int b1= Convert.ToInt32(Console.ReadLine());
            int result = Multiply(a1, b1);
            WriteLine("Result: " + result);

        }
    }

    public class ListPractice { 
        public void ListExample()
        {
            List<int> numbers= new List<int>();
            numbers.Add(10);
            numbers.Insert(1, 345678);
            numbers.Capacity = 20;
            for(int i=0;i< 6; i++)
            {
                WriteLine("Enter no.");
                int numbers1= Convert.ToInt32(Console.ReadLine());
                    numbers.Add(numbers1);
            }
            foreach (int num in numbers)
            {
                Write(num+ " ");
            }

            List<int> numberonly5= new List<int>();
            foreach (int num2 in numberonly5)
            {
                if (num2<5)
                {
                    WriteLine("Enter no....");
                    int numbers2 = Convert.ToInt32(Console.ReadLine());
                    numberonly5.Add(numbers2);



                }


            }
            foreach (int num in numberonly5)
            {
                Write(num + " ");
            }


            }
    }
}
