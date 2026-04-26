using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basics
{
    internal class FileManagementPracticeagain
    {
        public void CreateFile()
        {
            // Step 1: Create + Write
            //File.WriteAllText("data1.txt", "Hello Vishal sharma");

            //// Step 2: Append using FileInfo
            //FileInfo fr = new FileInfo("data1.txt");

            //using (StreamWriter sw = fr.AppendText())
            //{
            //    sw.WriteLine("\nWelcome to C# programming");
            //    sw.WriteLine("\nThis is a file management practice.");
            //}

            //// Step 3: Read AFTER writing is done
            //string data = File.ReadAllText("data1.txt");
            //Console.WriteLine(data);

            //------------------------------------------------------------------

            //WriteLine("Please enter your name : ");
            //string str = ReadLine();
            //WriteLine("Please enter 2nd name : ");
            //string str1 = ReadLine();
            //WriteLine("Please enter  3rd name : ");
            //string str2 = ReadLine();

            //File.WriteAllText("data2.txt","Welcome \n");
            //FileInfo fq= new FileInfo("data2.txt");
            //using(StreamWriter sdq= fq.AppendText())
            //{
            //    sdq.WriteLine("Name : "+str);
            //    sdq.WriteLine("Name : "+str1 + "\n");
            //    sdq.WriteLine("Name : "+str2);
            //}
            //-------------------------------------------------------------------------
            FileInfo fqq = new FileInfo("Abc.txt");
            using (StreamWriter sa = fqq.CreateText())
            {
                sa.WriteLine("Hello Vishal Sharma");
                sa.WriteLine("Thia is a new file created using FileInfo class.");

            }
            using (StreamWriter sa = fqq.AppendText()) { 
                sa.WriteLine("This is an appended line to the existing file.");
            }
            //fqq.CopyTo("data.txt", true);
            //fqq.MoveTo("data1.txt");


            //--------------
            //Directory
            
            Directory.CreateDirectory("dpracticefolder");
            if (Directory.Exists("dpracticefolder"))
            {
                WriteLine("Directory created successfully.");
            }
            //File.WriteAllText("dpracticefolder\\info.txt", "This file is created inside the directory.");
            //File.WriteAllText("dpracticefolder\\info1.txt", "This second file is created inside the directory.");
            //--------------------Both are same but we can use either of them-----------------------
            //File.WriteAllText(@"dpracticefolder\info.txt", "This file is created inside the directory.");  
            //File.WriteAllText(@"dpracticefolder\info1.txt", "This second file is created inside the directory.");
            string folder = "dpracticefolder";
            string file1= Path.Combine(folder,"info.txt");
            string file2= Path.Combine(folder,"info1.txt");
            File.WriteAllText(file1, "This file is created inside the directory");
            File.WriteAllText(file2, "This second file is created inside the directory.");
            string[] files = Directory.GetFiles("dpracticefolder");
            foreach(string file in files)
            {
                Console.WriteLine(file);
                string sr = File.ReadAllText(file);
                Console.WriteLine(sr);
            }

            WriteLine("How many files do you want to create inside the directory? ");
            int n;
            bool success = int.TryParse(ReadLine(), out n);
            if (!success)
            {
                WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            string foldername = "Data";
            Directory.CreateDirectory(foldername);
            for(int i = 0; i < n; i++)
            {
                string file = Path.Combine(foldername, $"file{i}.txt");
                WriteLine($"Enter content for file {i + 1}:");
                string input = ReadLine();

                File.WriteAllText(file, input);



            }
            string[] newFiles = Directory.GetFiles(foldername);

            foreach (string f in newFiles)
            {
                WriteLine("\nFile: " + f);
                WriteLine(File.ReadAllText(f));
            }
            DateTime creationTime = Directory.GetCreationTime(foldername);
            DateTime lastAccessTime = Directory.GetLastAccessTime(foldername);
            WriteLine($"Directory Creation Time: {creationTime}");
            WriteLine($"Directory Last Access Time: {lastAccessTime}");
            
            //Directory Info
            DirectoryInfo di = new DirectoryInfo("dpracticefolder");
            //di.Create();
            //if (di.Exists)
            //{
            //    WriteLine("Directory created successfully using DirectoryInfo class.");
            //}
            FileInfo[] fl = di.GetFiles();
            foreach(FileInfo f in fl)
            {
                WriteLine("File Name: " + f.Name);
                WriteLine("File Size: " + f.Length + " bytes");
                WriteLine("Creation Time: " + f.CreationTime);
                WriteLine("Last Access Time: " + f.LastAccessTime);
                WriteLine("Extension: " + f.Extension);
                WriteLine("Full Path: "  + f.FullName);
                WriteLine();
            }
            DirectoryInfo[] dd = di.GetDirectories();
            foreach(DirectoryInfo dl in dd)
            {
                WriteLine(dl.Name);
            };

            WriteLine("Full Path: " + di.FullName);
            WriteLine("Parent: " + di.Parent);
            WriteLine("Root: " + di.Root);
            WriteLine("Last Modified: " + di.LastWriteTime);
            //Directory.Delete(foldername);
            //Directory.Delete("folder")sirf tab chalega jab folder empty ho


            //Directory.Delete(foldername, true); //agr andr ka sb kuch delete krna ho to
            //if (Directory.Exists(foldername))
            //{
            //    Directory.Delete(foldername, true);
            //}

            //File info 
            //1. CreateText
            FileInfo d = new FileInfo("Fwp.txt");
            using(StreamWriter sw= d.CreateText())
            {
                sw.WriteLine("Hi this is a new file ..... ");
            }
            using (StreamWriter sd = d.AppendText())
            {
                sd.WriteLine("Lo fir aagye!");
            }
            //Open Write

            FileInfo jk = new FileInfo("data1.txt");
            using (FileStream r1 = jk.OpenWrite())
            {
                r1.Seek(0, SeekOrigin.End);//content last me add hoga file me 
                //r1.Seek(10, SeekOrigin.Begin);//ye 5th index se write krega  
                //r1.Seek(2, SeekOrigin.Current);//current position se 2 aage 
                using (StreamWriter fs = new StreamWriter(r1))
                {
                    fs.WriteLine("All is well..");
                }
            }
            //open read
            FileInfo sl = new FileInfo("data1.txt");
            using (FileStream fs = sl.OpenRead()) {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string data = sr.ReadToEnd();
                    Console.WriteLine(data);
                }

            }
            //image ke liye 
            //FileInfo ft = new FileInfo("Photo.jfif");
            //using(FileStream fd= ft.OpenRead())
            //{
            //    byte[] buffer = new byte[fd.Length];
            //    fd.Read(buffer, 0, buffer.Length);
            //    WriteLine(buffer.Length);
            //    File.WriteAllBytes("copy.jfif", buffer);
            //    WriteLine("------------------------");

            //    //image show krne ke liye 
            //    //Process.Start(new ProcessStartInfo("copy.jfif")
            //    //{
            //    //    UseShellExecute = true
            //    //});
            //}
            FileInfo f4 = new FileInfo("test.txt");

            using (StreamWriter sw = f4.CreateText())
            {
                sw.WriteLine("Hello Vishal");
            }
            WriteLine("--------------------------------");


            using (FileStream fs = new FileStream("test.txt", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Line 1");
            }

            using (FileStream fs = new FileStream("test.txt", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("Line 2");
            }
            //Append 

            using(FileStream fs= new FileStream("test.txt",FileMode.Append))
            using(StreamWriter sw= new StreamWriter(fs))
            {
                sw.WriteLine("\n Line 3 ");

            }
            using(FileStream fs= new FileStream("test.txt",FileMode.Append))
            using(StreamWriter sw= new StreamWriter(fs))
            {
                sw.WriteLine("\n Line 4 ");

            }

            //File Access

            //using (FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Read))
            //{
            //    using(StreamWriter ss= new StreamWriter(fs))
            //    {
            //        ss.WriteLine("Hi Vishal how are you ");
            //    }
            //}//exception aayega because of that file jo h wo read kr skte h only upr file access me fix kr rkha h ...
            //            FileAccess.Read → sirf read allowed
            //StreamWriter → write kar raha hai


            //        FileStream fs1 = new FileStream("lock.txt",
            //        FileMode.OpenOrCreate,
            //        FileAccess.ReadWrite,
            //        FileShare.None);

            //        Console.WriteLine("File locked... press enter to release");
            //        Console.ReadLine();

            string folder1 = "Data";
            string file11 = "file0.txt";

            string path = Path.Combine(folder1, file11);
            WriteLine("-----------------------------------------");

            WriteLine(path);
            WriteLine(Path.GetFullPath(path));
            WriteLine(Path.GetFileNameWithoutExtension(path));
            WriteLine(Path.GetDirectoryName(path));
            WriteLine(Path.GetFileName(path));

            WriteLine(File.Exists(path));         
            WriteLine(Directory.Exists(folder1));  

            WriteLine(Path.ChangeExtension(path, ".pdf"));
            WriteLine(Path.HasExtension("data.txt"));

            //I Copied below commented code 

            //// 1. Path + Combine
            //string folder = "Data";
            //string file = "report.txt";
            //string path = Path.Combine(folder, file);

            //Console.WriteLine("Path: " + path);

            //// 2. Directory
            //if (!Directory.Exists(folder))
            //{
            //    Directory.CreateDirectory(folder);
            //    Console.WriteLine("Folder Created");
            //}

            //// 3. File Create + Write
            //File.WriteAllText(path, "Hello Vishal");

            //// 4. Append
            //File.AppendAllText(path, "\nWelcome to File Handling");

            //// 5. Read
            //string content = File.ReadAllText(path);
            //Console.WriteLine("File Content:\n" + content);

            //// 6. FileInfo
            //FileInfo fi = new FileInfo(path);

            //Console.WriteLine("Name: " + fi.Name);
            //Console.WriteLine("Size: " + fi.Length);
            //Console.WriteLine("Created: " + fi.CreationTime);

            //// 7. Stream (Write)
            //using (FileStream fs = new FileStream(path, FileMode.Append))
            //using (StreamWriter sw = new StreamWriter(fs))
            //{
            //    sw.WriteLine("Stream Writing Line");
            //}

            //// 8. Stream (Read)
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //using (StreamReader sr = new StreamReader(fs))
            //{
            //    Console.WriteLine("Stream Read:\n" + sr.ReadToEnd());
            //}

            //// 9. Path Analysis
            //Console.WriteLine("Extension: " + Path.GetExtension(path));
            //Console.WriteLine("FileName: " + Path.GetFileName(path));
            //Console.WriteLine("Directory: " + Path.GetDirectoryName(path));

            //// 10. Copy File
            //string copyPath = Path.Combine(folder, "copy.txt");
            //File.Copy(path, copyPath, true);

            //// 11. Move File
            //string movedPath = Path.Combine(folder, "moved.txt");
            //File.Move(copyPath, movedPath, true);

            //// 12. Delete File
            //File.Delete(movedPath);

            //Console.WriteLine("Done All Operations 💣");
            WriteLine("------------------------------------------------------------");

            //Environment class

            WriteLine("Machine " + Environment.MachineName);
            WriteLine("User " + Environment.UserName);
            WriteLine("Os " + Environment.OSVersion);
            WriteLine("Current Dir " + Environment.CurrentDirectory);
            WriteLine("Processors: " + Environment.ProcessorCount);
            WriteLine("Hello" + Environment.NewLine + "Vishal");
            //Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Desktop ke liye 

            string DeskTop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path5 = Path.Combine(DeskTop, "File.txt");
            File.WriteAllText(path5, "Hi Vishal ");

            ////Mydocuments
            //string doc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string pathh = Path.Combine(doc, "TestingFile.txt");
            //File.WriteAllText(pathh, "Hello my dear friend");





        }
    }
}