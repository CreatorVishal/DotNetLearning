

using System.Runtime.InteropServices.Marshalling;

namespace Basics
{
    //internal class WorkingwithFiles
    //{

    //    public void CreateFile()
    //    {
    //        File.WriteAllText("testu.txt", "Hello Vishal sharma");
    //    }
    //}
    //public static class Filesmanagement
    //{
    //    public static void WriteFile()
    //    {
    //        File.WriteAllText("D:\\Tetsing.txt","Aajao saare coding kre ");
    //    }
    //}

    public static class UserInput1
    {
        public static void GetUserInput()
        {
            WriteLine("Enter your name:");
            string name = ReadLine();
            File.WriteAllText("user.txt", name);
            File.Create("Sample.text").Close();//This will create a file named "Sample.text" and close it immediately to release the file handle.
            File.AppendAllText("user.txt", "\nWelcome to C# programming, " + name + "!");

            //Directory.CreateDirectory("New folder");
            // string currentPath = Directory.GetCurrentDirectory();
            // WriteLine("Current directory: " + currentPath);
            string str = Path.Combine(Directory.GetCurrentDirectory(), "Myfolder");
            Directory.CreateDirectory(str);
            WriteLine("Directory created at: " + str);

            FileInfo fi = new FileInfo("user.txt");
            WriteLine("File Name: " + fi.Name);
            WriteLine("File Size: " + fi.Length + " bytes");
            WriteLine(fi.Exists);
            File.Delete("user.txt");

            WriteLine(Path.GetTempFileName());

            //desktop pr file ke liye 

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string path= Path.Combine(desktop,"Myfolder");
            //File.WriteAllText(path, "This is a file on the desktop.");

          
            string deskfile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string path1 = Path.Combine(deskfile, "hello.txt");
            File.WriteAllText(path1, "hello tx file on desktop");

            string deskfilejj = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //documents me file 
            //string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string path2 = Path.Combine(documents, "My folder");
            //File.WriteAllText(path2, "This is a file in the Documents folder.");

            string path4 = "C:\\New_Folder\\sample.txt";
            WriteLine(path4);
            File.WriteAllText(path4, "This is a sample file in the New_Folder directory.");

            using (StreamWriter sw = new StreamWriter("Ok.txt"))
            {
                sw.WriteLine("Hello Vishal !");
            }
            using (StreamReader sr = new StreamReader("Ok.txt"))
            {
                string content = sr.ReadToEnd();
                WriteLine("Content of Ok.txt: " + content);
               
            }
           var result = File.Exists("Ok.txt");
            WriteLine(result);


            Directory.CreateDirectory("Practice folder ");
            var getfilesprac = Directory.GetFiles("Practice folder ");
            var getparentc=Directory.GetParent("Practice folder ");

            WriteLine(getfilesprac);
            foreach (var file in getfilesprac)
            {
                Console.WriteLine(file);
            }
            WriteLine("--------------------"+getparentc.FullName);


            if (Directory.Exists("Practice folder "))
            {
                WriteLine("Directory Exist ");
                WriteLine("Path of this directory is : " + Directory.GetCurrentDirectory());
            }

            Write(Directory.GetCurrentDirectory());
            string path6 = Path.Combine("D:", "New Folder 1", "Sample11.txt");

            WriteLine(Directory.GetParent(path6));

            if (Directory.Exists(Directory.GetParent(path6).FullName))
            {
                WriteLine("Directory exist");
            }
            else
            {
                WriteLine("Directory does not exist");
                Directory.CreateDirectory("New folder 1");
            }


            using (FileStream fs = new FileStream("Ok.txt", FileMode.Create))
            {
                if (File.Exists("Ok.txt"))
                {
                    WriteLine("File exist");

                    string Paths = Path.Combine(Directory.GetCurrentDirectory(), "Ok.txt");
                    WriteLine(Paths);
                }
                else
                {
                    WriteLine("File does not exist");
                }
            }
            


        }
    }
    //public static class readingFiles
    //{
    //    public static void readFiles()
    //    {
    //        string data = File.ReadAllText("user.txt");
    //        WriteLine("Data is : "+data);

    //    }
        
    //}






    



    
      
}
