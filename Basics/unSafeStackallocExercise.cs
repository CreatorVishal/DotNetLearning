namespace Basics
{
    internal class unSafeStackallocExercise
    {
        //public unsafe void normalmethod()
        //{

        //    PracticeStack();

        //}
        public  void normalmethod()
        {
            unsafe
            {
                PracticeStack();
            }
        }

        public unsafe void PracticeStack()
        {
            int* arr = stackalloc int[3];

            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;

            WriteLine($"{arr[0]}, {arr[1]}");
        }
    }
}