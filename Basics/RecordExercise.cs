
using System.Buffers.Text;

//Record default me reference type hota hai (class jaisa).
//Record value-based equality use karta hai (data compare hota hai, reference nahi).
//Record immutable hota hai by default (init properties hoti hain).
//Record automatically constructor, Equals, GetHashCode, ToString generate karta hai.
//🔹 SYNTAX
//Positional record → record Student(string Name, int Age);
//Full record → properties manually define kar sakte hain.
//Record struct → record struct A(int x); (value type)
//🔹 MUTABILITY
//Record class me direct change allowed nahi → st.Name = "A" ❌
//Change ke liye with use hota hai → st2 = st1 with { Name = "B" }
//Record struct me direct change allowed hota hai → a.x = 10 ✔
//Record struct ko immutable bhi bana sakte hain → readonly record struct
namespace Basics
{
    public record Student(string Name, int age);

    record struct A(int x);

    record Car(string name, int year)
    {
        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {name}, Year: {year}");
        }
    }
    

    
}
