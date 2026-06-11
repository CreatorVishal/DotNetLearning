using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Basics
{
    // File  FileInfo
    // Directory DirectoryInfo
    // Stream    FileStream
    // StreamWriter
    // StreamReader

    // BinaryWriter
    // BinaryReader

    // MemoryStream

    // Path
    internal class ReviseFileHandling
    {
        public ReviseFileHandling()
        {
            File.WriteAllText("Student.txt", "Hello Vishal Sharma from Rohtak I know you are doing MCA....");
            WriteLine("File Created");
            string data = File.ReadAllText("Student.txt");
            WriteLine(data);

            //Append Text
            File.AppendAllText("Student.txt", "What's Going On now a days ");
            string data11 = File.ReadAllText("Student.txt");
            WriteLine(data11);

            //Exists
            WriteLine(File.Exists("Student.txt"));
            //Copy
            File.Copy("Student.txt", "Student1.txt");

            //Delete
            if (File.Exists("Student1.txt"))
            {
                File.Delete("Student1.txt");
            }
            ////Move
            //File.Move("test.txt", "test1.txt");

            //WriteAllLines
            string[] Dta1 =
            {
                "Rahul",
                "Ronak",
                "Sunil"
            };
            File.WriteAllLines("Student2.txt", Dta1);
            //ReadAllLines
            string[] dnt = File.ReadAllLines("Student2.txt");
            //WriteLine(dnt);---->System.String[]
            foreach (var i in dnt)
            {
                Write(" " + i + " ");
            }

            //--------------------------------
            //-----------------------------FileInfo
            FileInfo fi1 = new FileInfo("Student.txt");
            WriteLine(fi1.Name);
            WriteLine($"Name : {fi1.Name}");
            // Extension
            WriteLine($"Extension : {fi1.Extension}");
            // Exists

            WriteLine($"Exists : {fi1.Exists}");
            // Length (Size in Bytes)
            WriteLine($"Length : {fi1.Length}");
            // Creation Time
            WriteLine($"Creation Time : {fi1.CreationTime}");
            // Last Modified Time

            WriteLine($"Last Write Time : {fi1.LastWriteTime}");
            // Directory Name
            WriteLine($"Directory : {fi1.DirectoryName}");
            // Full Path
            WriteLine($"Full Name : {fi1.FullName}");
            ////Move to

            //FileInfo fi2 =new FileInfo("h2.txt");

            //fi2.MoveTo( "StudentMove.txt");

            //-------------Directory---------------------------------------------------------------
            Directory.CreateDirectory("StudentFolder");
            //Exists

            WriteLine(Directory.Exists("StudentFolder"));

            //agr folder me files bnani ho to 
            //File.WriteAllText(@"StudentFolder\AA1.txt","First file h ye ");


            //Get files 
            string[] getAllfiles = Directory.GetFiles("StudentFolder");
            foreach(var file in getAllfiles)
            {
                Write(" " + file + " ");
            }
            Directory.CreateDirectory(@"StudentFolder\MCA");
            Directory.CreateDirectory(@"StudentFolder\BCA");

            //Get Folder in Folder
            string[] getAllFolder = Directory.GetDirectories("StudentFolder");
            foreach(var item in getAllFolder)
            {
                WriteLine(item);
            }
            //Delete Directory--> done
            //Directory.Delete("StudentFolder",true);
            //--------------------------Directory Info-----------------
            DirectoryInfo di1 =new DirectoryInfo("StudentFolder");
            // Properties
            WriteLine($"Name : {di1.Name}");

            WriteLine($"Exists : {di1.Exists}");

            WriteLine($"Full Path : {di1.FullName}");

            WriteLine($"Created : {di1.CreationTime}");
            //Methods
            //1.GetFiles-->yha string use nhi hoga fileinfo use hoga 

            FileInfo[] AllFiles = di1.GetFiles();
            foreach(var i in AllFiles){
                WriteLine(i);
            }

            //2.GetDirectories
            DirectoryInfo[] AllFolders = di1.GetDirectories();
            foreach(var i in AllFolders)
            {
                WriteLine(i);
            }
            //3.Delete Directory
            // Delete()

            //DirectoryInfo di3 = new DirectoryInfo("StudentFolderNew");

            //di3.Delete(true);

            //WriteLine("Folder Deleted");
            //-----------------------------------Path----------------------
            //-------------------------------- PATH

            string path =Path.Combine( "StudentFolder","Resume.pdf" );

            WriteLine($"Path : {path}" );

            WriteLine($"File Name : {Path.GetFileName(path)}");

            WriteLine( $"Extension : {Path.GetExtension(path)}");

            WriteLine( $"Without Extension : {Path.GetFileNameWithoutExtension(path)}");

            WriteLine($"Directory : {Path.GetDirectoryName(path)}");

            WriteLine(Path.ChangeExtension(path,"txt")  );

            //-------------------------------------File stream-----------
            //1.Create
            using FileStream fss1 = new FileStream("Tomy.txt", FileMode.Create);
            WriteLine("Done");

            byte[] data2 = Encoding.UTF8.GetBytes("Hello Vishal sharma");
            fss1.Write(data2, 0, data2.Length);

            //Read 
            using FileStream fss2 = new FileStream("Tomy.txt",FileMode.Open);

            byte[] readData = new byte[fss2.Length];
            fss2.Read(readData, 0, readData.Length);

            string result = Encoding.UTF8.GetString(readData);
            WriteLine(result);





        }
    }
}
