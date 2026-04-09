
namespace Basics.Animal
{
    internal class Animal
    {
        public string? Name { get; set; }
        public string? Description { get; set; } 
    }
   internal class Cat : Animal
   {
        public int? legs { get;set; } 
        public int? age { get; set; }


         
    }
    internal class Spider: Animal
    {
        public string spiderType { get; set; }
    }

    internal class Operation
    {
        internal Operation()       
        {
            var arr = new Animal?[]{
                new Cat{age=42,Description="Lore",legs=4,Name ="Maya"},
                new Cat{age=22,Description="Lodfghre",legs=2,Name ="Murli"},
                null,
                new Spider{Name="Spider1",spiderType="Dangerous"},
                new Spider{spiderType="Basic",Name="Kalu"},

                
            };
            string Message;
            foreach (Animal? animal in arr)
            {
                

                switch (animal)
                {
                    case Cat c when c.legs > 2:
                        Message = $"{c.Name}";
                        break;
                    case Cat c when c.age > 22:
                        Message = $"{c.Name}";
                        break;
                    case null:
                        Message = "Null item"; ;
                        break;
                    case Spider s :
                        Message = $"{s.Name}";
                        break;
                    default:
                        Message = "Default value";
                        break;
                       

                }
                WriteLine(Message);
            }
            

        } 


    } 


}

