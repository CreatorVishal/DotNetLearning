using Basics.France;
using Tx=Basics.Texas;
WriteLine("Hello, World!");
int age;
WriteLine("Enter age : ");
bool Success = int.TryParse(ReadLine(), out age);

if (Success)
{
    WriteLine($" Your age is :{ age}");
}
else
{
    WriteLine("Invalid Age...");
}
#region
int decimalNotation = 2_000_000;
int binaryRotation= 0b_0001_1110_1000_0100_1000_0000;
int hexaDecimalNotation = 0x_001E_8480;
WriteLine($"{ binaryRotation:N0}");
#endregion

//unary operator 
int x = 2;
WriteLine(x++);
WriteLine(++x);
WriteLine(x--);
WriteLine(--x);

Type theTypeOfAnInteger = typeof(int);
string nameOfVariable = nameof(x);
WriteLine(nameOfVariable);

string? eName=null;

int? len = eName?.Length?? 30;
WriteLine(len);

int? age1 = 32;
WriteLine(age1 ?? 45);

//----------------------

int p = 6;
p += 3; 
p -= 3; 
p /= 3; 
p *= 3;

WriteLine(p);


WriteLine(3 << 3); //24
WriteLine(4 >> 2);
int y=5;
WriteLine($"y << 3 | {y << 3,7} | {y << 3:B8}");
char ch = 'd';

WriteLine(typeof(int));//System.Int32
WriteLine(nameof(y));//y
WriteLine(sizeof(char));//2


//-------------------------


object one="Vishal";
string? cdd = one as string;
if (one is string)
{
    WriteLine("Yes You are right...");
}
WriteLine(cdd.Length);


string password = "ninja";
if (password.Length < 8)
{

    WriteLine("Your password is too short. Use at least 8 chars.");
  
}

else
{
    WriteLine("Your password is strong.");
}

string GetStatus(int score)
{
    if (score < 50)
    {
        return "Fail";
    }
    return "Pass";
}

WriteLine(GetStatus(30));

//---------/
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // Jumps to end of switch statement.
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: // Multiple case section.
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
     
    default:
        WriteLine("Default");
        break;
} 
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");

//Dog obj = new Dog();
//obj.sound();
Operation obj = new Operation();


string[,] str =
{
    { "Vishal", "Montu", "Kapil" },
    { "Rani", "Deepika", "Ananya" }
};

for (int i = 0; i < str.GetLength(0); i++) // rows
{
    for (int j = 0; j < str.GetLength(1); j++) // columns
    {
        Console.WriteLine($"[{i},{j}] = {str[i, j]}");
        WriteLine(str[i, j]);
    }
};



WriteLine(str.GetLowerBound(0));
WriteLine(str.GetUpperBound(1));

//jagged array

string[][] jagged =
{
    new[] { "Alpha", "Beta", "Gamma" },    
    new[] { "Anne", "Ben", "Charlie", "Doug" },
    new[] { "Aardvark", "Bear" }             
};

try
{
    for (int i = 0; i < jagged.Length; i++)
    {
        for (int j = 0; j < jagged[i].Length; j++)
        {
            WriteLine(jagged[i][j] + " ");

        }
        WriteLine();


    }

}
catch (IndexOutOfRangeException)
{
    WriteLine("Index out of bound");
}


string input = ReadLine();

try
{
    int num = int.Parse(input);
    WriteLine(num);

}
catch (Exception ex)
{
    WriteLine(ex.Message);
}

try
{

    int num3 = int.Parse(ReadLine());
}
catch (FormatException)
{
    WriteLine("Wrong format");
}
catch (OverflowException){
    WriteLine("Number you entered is big ");
}
finally
{
    WriteLine("Always Run");
}
if (number < 0)
{
    throw new Exception("Invalid num");
};

//public int ok = 0; //field
//public int num5 {get;set;} // property

//Types of field 
const int Max = 100;//constant

//Readonly
//readonly int age3;

//public Person()
//{
//    age3 = 25;
//}














//Paris p1 = new(); //yha error aata is liye hmne ek namespace ko alias bna diya  
//like this  -------- alias = nickname of namespace 
//using Basics.France;
//using Tx=Basics.Texas;Now we can use easily 

Paris p1 = new();
Tx.Paris p2 = new();

Student1 s1 = new Student1("Vishal sharma");
Student1 s2 = new Student1(22,"Vishal sharma");

//s1.name = "Vishal";
//s1.age = 22;

WriteLine(s1.Name);
WriteLine(s1.Age);
WriteLine(s2.Name);
WriteLine(s2.Age);
WriteLine(s1.IsAdult());
//s1.printDetails();
WriteLine(s1.GetInfo());
WriteLine("--------------------------------------------------------");

List<Student1> students = new List<Student1>();

students.Add(new Student1(23, "Vishal"));
students.Add(new Student1(17, "Rahul"));
students.Add(new Student1("Aman")); // default age
foreach (var s in students)
{
    WriteLine(s.GetInfo());
}



int[] num2={10,20,30,40};
foreach (int r in num2)
{
    WriteLine(r);
}

int sum2 = 0;

foreach (int x2 in num2)
{
    sum2 += x2;
}
WriteLine(sum2 + " ");

Student1.Print(10);
Student1.Print("Vishal Sharma");
Student1.pppp();

object? data = null;
string? str4 = data as string;
if(str4 != null)
{    
    WriteLine(str4);

}
