

namespace Basics
{
    internal class TuplePrac
    {
        public (bool, string ) SaveData()
        {
            return (true, "Saved successfully");
        }
        public TuplePrac() {
            var(value,message) = SaveData();
                WriteLine($"Value : {value} , Message : {message}");
        }
    }
}
