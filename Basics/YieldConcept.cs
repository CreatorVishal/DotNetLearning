

namespace Basics
{
    internal class YieldConcept
    {
        internal IEnumerable<int> GetNumbers() {
            for (int i = 0; i < 5; i++)
            {
                WriteLine(i);
                yield break;
            }
            
        }
        //-------------------------------
        //Tuple
        public (string name, int age) GetPersonInfo()
        {
            return ("Vishal sharma", 22);
        }
    }

   
    
}
