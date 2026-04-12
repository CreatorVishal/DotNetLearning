

namespace Basics
{
   interface IRun{
        void Run();
       
    }
    interface Ijump {
        void Jump();
    }
    class Person : IRun, Ijump {
       public void Run()
        {
            WriteLine("Running");
        }
       public void Jump() {
            WriteLine("Jumping");
        }
    }
}
