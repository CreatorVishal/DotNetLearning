

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
    public class practicefiles
    {
        public void createFiles1()
        {
            //string path = "Practice_File.txt";
            //File.WriteAllText(path,"Hi\nI am Vishal Sharma\n I am doing MCA " );
            //string data = File.ReadAllText(path);
            //WriteLine(data);

            //File.Copy("Practice_File.txt", "testu.txt", true); //agr true diya or destination file h to override krega or agr false diya to error throw krega like below example . 
            //try
            //{
            //    if (!File.Exists("testu.txt"))
            //    {
            //        File.Copy("Practice_File.txt", "testu.txt");
            //    }
            //    else
            //    {
            //        throw new Exception("File already exist");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WriteLine(ex.Message);
            //}
            //File.Move("testu.txt", @"D:\DotNetLearningAllfiles\CreatorVishal\DotNetLearning\Basics\New folder 1\testu.txt");

            //File.Replace(@"D:\DotNetLearningAllfiles\CreatorVishal\DotNetLearning\Basics\New folder 1", "ok.txt", "backupok.txt");

            //Directory

            //Directory.CreateDirectory("DiPractice-1");


            //FileInfo ff = new FileInfo("AtoZfileinfoprac.txt");
            //ff.Create().Close();

            //File.WriteAllText("AtoZfileinfoprac.txt", "This is a practice file for FileInfo class.");

            // WriteLine("--------------------------------------------------------------------------------------");
            // if(!File.Exists("data.txt"))
            // {
            //     File.WriteAllText("data.txt", "Name : Vishal \n Course: MCA");

            //     string data = File.ReadAllText("data.txt");
            //     WriteLine(data);
            // }
            // else
            // {

            //     WriteLine("File already exists");
            //     File.AppendAllText("data.txt", "\nAge: 23");
            // }
            //File.Copy("data.txt", "backupdata.txt", true);

            // WriteLine("File copied successfully to backupdata.txt");
            // WriteLine("----------------------------------------------");
            //FileInfo g = new FileInfo("fileinfo.txt");
            ////create a file 
            //g.Create().Close();
            ////If we want to write in this file then we can use below code
            //File.WriteAllText(g.FullName, "This is a practice file for FileInfo class.");
            //g.Refresh(); // Refresh the FileInfo object to update its properties after creating the file
            //WriteLine(g.Name);
            //WriteLine(g.Length);
            //WriteLine(g.Extension);
            //WriteLine(g.CreationTime);
            //g.CopyTo("ok.txt", true);
            //g.MoveTo("ok1.txt");
            //g.Refresh();
            //WriteLine("After Move: " + g.Name);

            //
            FileInfo f2 = new FileInfo("Pop.txt");
            //Write
            using (StreamWriter sw = f2.CreateText())
            {
                sw.WriteLine("Hello Vishal sharma How are you ?");
                sw.WriteLine("Where are you from ?");
                //string dataq= File.ReadAllText("Pop.txt");
                // WriteLine("Data in Pop.txt: " + dataq);//exception aayegi because file is open in write mode and we are trying to read it. To avoid this we can use sw.Flush() to flush the buffer and then read the file or we can close the streamwriter and then read the file.


            }
            //Read
            using (StreamReader sjk = f2.OpenText())
            {
                string content = sjk.ReadToEnd();
                WriteLine("Content of Pop.txt: " + content);
            }

        }
    }






    



    
      
}
