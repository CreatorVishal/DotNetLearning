

namespace Basics
{
  //  Rules of operator overloading
  //1. It is only applied classes, struct and record
  //2. operator overloading perform by objects only
  //3. Always Make function to perform any operator overloading and use operator keyword
  //4. function are make only public static
  //5. can't overloaded these operators in operator overloading Assignment operators += -= /= *= etc & Logical Operators && || !
  //*/
   
    public class Vector
    {
        public int x, y;


        //constructor


        //creating operator overloading function remember always make public static
        public static Vector operator +(Vector ob1, Vector ob2)
        {
            Vector objNew = new Vector();
            objNew.x = ob1.x + ob2.x;
            objNew.y = ob1.y + ob2.y;

            return objNew;
        }

        //operator overloading multiply
        public static Vector operator *(Vector ob1, Vector ob2)
        {
            Vector objNew = new Vector();
            objNew.x = ob1.x * ob2.x;
            objNew.y = ob1.y * ob2.y;

            return objNew;
        }


    }

    internal class OperatorOverloading
    {
        internal OperatorOverloading()
        {
            Vector obj1 = new Vector();
            Vector obj2 = new Vector();

            obj1.x = 10;
            obj1.y = 20;

            obj2.x = 5;
            obj2.y = 5;
            //operator overloading Addition
            Vector obj3 = obj1 + obj2;
            WriteLine("obj3 x = " + obj3.x + "\nobj3 y = " + obj3.y);

            //operator overloading multiply
            Vector obj4 = obj1 * obj2;
            WriteLine("obj4 x = " + obj4.x + "\nobj4 y = " + obj4.y);

        }

    }
    public class vector8 {
        public int i, j;
        public vector8(int i,int j)
        {
            this.i = i; 
            this.j= j;
        }
        public  static vector8 operator +(vector8 j1,vector8 j2)
        {
             
            return new vector8(j1.i + j2.i, j1.j + j2.j);
        }
       

    }
    internal class OperatorOverloadingConcept
    {
        public OperatorOverloadingConcept()
        {
            vector8 obj2 = new vector8(20,40);
            vector8 obj4 = new vector8(30, 20);
            vector8 obj5 = obj2 + obj4;

            WriteLine($"{obj5.i},{obj5.j}");
        }


    }
}
