

namespace Basics.Oops
{
    internal class Des
    {

        internal string name { get; set { 
            } }
        internal int age { get; set; }
        internal void Deconstruct(out string Name,out int Age) {
            Age = age;
            Name = name;
        }

    }
}
