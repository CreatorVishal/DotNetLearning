
using System.IO;
using System.IO.Compression;
using System.Runtime.Intrinsics.X86;


namespace Basics
{
    internal class CompressDecompress
    {
        public void Compress_Decom()
        {
            string text = "Hello Ramlal";
            //compress
            using (FileStream cf = new FileStream("CompressedFile.gz", FileMode.Create))
            using (GZipStream gZip = new GZipStream(cf, CompressionMode.Compress))
            using (StreamWriter sd = new StreamWriter(gZip))
            {
                sd.Write(text);

            }
            WriteLine("Compressed Successfully");

            using (FileStream cfd = new FileStream("CompressedFile.gz", FileMode.Open))
            using (GZipStream gzd = new GZipStream(cfd, CompressionMode.Decompress))
            using (StreamReader sdd = new StreamReader(gzd))
            {
                string resultDe = sdd.ReadToEnd();

                // new file me save(agr notepad me bhi dekhna ho text to)
                //File.WriteAllText("Decompressed.txt", resultDe);
                WriteLine(resultDe);

            }
            WriteLine("Decompressed successfully!");

            //WriteLine("-----------------------------------------------------------------------------------");


            //string file = "data.gz";
            //string text = "Hello Vishal Sharma";

            //// COMPRESS
            //using (FileStream fs = new FileStream(file, FileMode.Create))
            //using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
            //using (StreamWriter sw = new StreamWriter(gzip))
            //{
            //    sw.Write(text);
            //}

            //// DECOMPRESS
            //using (FileStream fs = new FileStream(file, FileMode.Open))
            //using (GZipStream gzip = new GZipStream(fs, CompressionMode.Decompress))
            //using (StreamReader sr = new StreamReader(gzip))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}

            //WriteLine("-----------------------------------------------------------------------------------");



            //Compress and Decompress Using bytes[]

            //Compression

            string Texta = "I am Vishal";
            byte[] datab = Encoding.UTF8.GetBytes(Texta);
            using (FileStream fsq = new FileStream("raw.gz", FileMode.Create))
            using (GZipStream NewGzip = new GZipStream(fsq, CompressionMode.Compress))
            {
                NewGzip.Write(datab);

            }
            //Decompression

            using (FileStream fsd = new FileStream("raw.gz", FileMode.Open))

            using (GZipStream DNewZip = new GZipStream(fsd, CompressionMode.Decompress))
            using (MemoryStream ms = new MemoryStream())
            {
                DNewZip.CopyTo(ms);
                ms.Position = 0;
                byte[] data11 = ms.ToArray();
                string resultDec = Encoding.UTF8.GetString(data11);
                //File.WriteAllText("DecompressedFile.txt", resultDec);
                WriteLine(resultDec);

            }

        }
       
        //-------------------------------------------------------------------

        //compress:
        //String → byte[] → GZipStream → File/Memory

        //Decompress:
        //   File/Memory → GZipStream → byte[] → String

        public void GzipPract()
        {
            string testPrac = "Hello Vishal........";
            string pract11 = "Hi Hello, Hi Hello,Hi Hello, Hi Hello,Hi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi HelloHi Hello, Hi Hello";

            WriteLine("Normal size: " + testPrac.Length);
            WriteLine("Repeat size: " + pract11.Length);

            // string → bytes
            byte[] dataPrac = Encoding.UTF8.GetBytes(testPrac);

            // compress
            using (FileStream fsp = new FileStream("dataPrac.gz", FileMode.Create))
            using (GZipStream gzPrac = new GZipStream(fsp, CompressionMode.Compress))
            {
                gzPrac.Write(dataPrac, 0, dataPrac.Length);
            }

            Console.WriteLine("Compression done");

            using (FileStream fspd = new FileStream("dataPrac.gz", FileMode.Open))
            using (GZipStream gzl = new GZipStream(fspd, CompressionMode.Decompress))
            using (MemoryStream mss = new MemoryStream())
            {
                gzl.CopyTo(mss);
                string res = Encoding.UTF8.GetString(mss.ToArray());
                WriteLine(res);

            }

            //large string
            byte[] aa = Encoding.UTF8.GetBytes(pract11);
            using (FileStream fd = new FileStream("aa.gz", FileMode.Create))
            using (GZipStream ds = new GZipStream(fd, CompressionMode.Compress))
            {
                ds.Write(aa,0,aa.Length);
               

            }
            WriteLine("Compressed Successfully!");

            using (FileStream sdk = new FileStream("aa.gz", FileMode.Open))
            using (GZipStream Decom = new GZipStream(sdk, CompressionMode.Decompress))
            using (MemoryStream ss = new MemoryStream())
            {
                Decom.CopyTo(ss);
                string ress = Encoding.UTF8.GetString(ss.ToArray());
                WriteLine(ress);
            }

            //File->File compression
            using (FileStream input = new FileStream("data.txt", FileMode.Open))
            using (FileStream Output = new FileStream("zpfile.gz", FileMode.Create))
            using (GZipStream sdgzip = new GZipStream(Output, CompressionMode.Compress))
            {
                input.CopyTo(sdgzip);
            }

            using(FileStream input1= new FileStream("zpfile.gz",FileMode.Open))
                using(GZipStream ds= new GZipStream(input1,CompressionMode.Decompress))
                using(FileStream Output1= new FileStream("output.txt", FileMode.Create))
            {
                ds.CopyTo(Output1);
            }




        }
        //Gzip end 


        //public void ziprac()
        //{
        //    string sourceFolder = "dpracticefolder";
        //    string newZip = "dpracticefolder.zip";
        //    string extract = "OpFolderNew";

        //    try
        //    {
        //        // check folder exist
        //        if (!Directory.Exists(sourceFolder))
        //        {
        //            WriteLine("Source folder nahi mila ❌");
        //            return;
        //        }

        //        // delete old zip
        //        if (File.Exists(newZip))
        //        {
        //            File.Delete(newZip);
        //        }

        //        // 1. Create Zip
        //        ZipFile.CreateFromDirectory(sourceFolder, newZip);
        //        WriteLine("Zip folder created");

        //        // 2. Unzip
        //        if (Directory.Exists(extract))
        //        {
        //            Directory.Delete(extract, true);
        //        }

        //        ZipFile.ExtractToDirectory(newZip, extract);
        //        WriteLine("Unzip ho gaya");

        //        // 3. Read
        //        using (ZipArchive zx = ZipFile.OpenRead(newZip))
        //        {
        //            WriteLine("Zip ke andar files:");
        //            foreach (var i in zx.Entries)
        //            {
        //                WriteLine(i.Name);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLine("Error: " + ex.Message);
        //    }
        //}


        //Zip File start

        //Created
        public void zpFile()
        {
            try
            {
            string basePath= @"D:\DotNetLearningAllfiles\CreatorVishal\DotNetLearning\Basics";
            string source_Folder = Path.Combine(basePath, "ZipPractice");
            string zpFilee = Path.Combine(basePath, "ZipPractice.zip");
            string extractFolder = Path.Combine(basePath, "OutputFolder");
            if (!Directory.Exists(source_Folder))
            {
                WriteLine("source Folder nhi mila");

            }
            if (File.Exists(zpFilee))
            {
                File.Delete(zpFilee);
            }
            ZipFile.CreateFromDirectory(source_Folder, zpFilee);
            WriteLine("Zip file create ho gyi ");

            if (Directory.Exists(extractFolder))
            {
                Directory.Delete(extractFolder,true);
            }
            ZipFile.ExtractToDirectory(zpFilee, extractFolder);
                WriteLine("Unzip done");

                using (ZipArchive zx = ZipFile.OpenRead(zpFilee))
                 {
                    foreach(var item in zx.Entries)
                    {
                        WriteLine(item.Name);
                    }
                } 
            }
            catch(Exception ex)
            {
                WriteLine("Error: " + ex.Message);
            }

        }
        //ZipFile end
        //Zip Archive start
        public void Zarc()
        {
            if (!Directory.Exists("Paris11"))
            {
                WriteLine("Doesn't exist making a new directory...");
                Directory.CreateDirectory("Paris11");

            }
            if (File.Exists("Z.zip"))
            {
                File.Delete("Z.zip");
            }
            ZipFile.CreateFromDirectory("Paris11", "Z.zip");

            WriteLine("zipFile Created ");

            if (Directory.Exists("extractPath1"))
            {
                Directory.Delete("extractPath1", true);

            }
            ZipFile.ExtractToDirectory("Z.zip", "extractPath1"); //true use kr skte but recommended nhi h 
            WriteLine("Extract ho gya");

            File.WriteAllText("Jeevan.txt", "Hello brother you are getting late.. ");
            File.WriteAllText("a.txt", "File A");
            File.WriteAllText("b.txt", "File B");
            File.WriteAllText("c.txt", "File C");
            if (File.Exists("Z.zip"))
            {
                File.Delete("Z.zip");
            }
            using (ZipArchive archive = ZipFile.Open("Z.zip", ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile("Jeevan.txt", "Jeevan1.txt");
                archive.CreateEntryFromFile("a.txt", "a11.txt");
                archive.CreateEntryFromFile("b.txt", "b11.txt");
                archive.CreateEntryFromFile("c.txt", "c11.txt");

            }
            WriteLine("Multiple files zip me add ho gayi...");

            using (ZipArchive archive = ZipFile.OpenRead("Z.zip"))
            {
                foreach (var n in archive.Entries)
                {
                    WriteLine("Name : " + n.Name);
                    WriteLine($"Size: {n.Length}");
                    WriteLine($"Compressed: {n.CompressedLength}");
                    WriteLine("------");
                   
                   
                }
            }

            File.WriteAllText("Sandy.txt", "Hi I am Sandy Superstar...");
            File.WriteAllText("Hell.txt", "We are in hell...");

            Write("----------------------------");

           using(ZipArchive zx= ZipFile.Open("Create.zip", ZipArchiveMode.Create))
            {
                zx.CreateEntryFromFile("Sandy.txt", "Sandy1.txt");
                zx.CreateEntryFromFile("Hell.txt", "Helln.txt");
            }

           using(ZipArchive zx = ZipFile.Open("Create.zip", ZipArchiveMode.Update))
            {
                var entry= zx.CreateEntry("InsideNow.txt");
                using(StreamWriter  sw = new StreamWriter(entry.Open()))
                {
                    sw.WriteLine("This file will directly create in zip folder and this text is written in insidenow text file ....  ");
                }

            }
           using(ZipArchive zp= ZipFile.OpenRead("Create.zip"))
            {
                foreach(var i in zp.Entries)
                {
                    WriteLine(i.Name);
                }

            }
            File.WriteAllText("h2.txt", "Ok");
            File.WriteAllText("h3.txt", "okk");
            using (ZipArchive zs = ZipFile.Open("lasttesting.zip", ZipArchiveMode.Create))
            {
                zs.CreateEntryFromFile("h2.txt", "h22.txt");
                zs.CreateEntryFromFile("h3.txt", "h33.txt");

            }

            using(ZipArchive ds= ZipFile.OpenRead("lasttesting.zip"))
            {
                WriteLine("zip ke andr ki files");
                foreach(var i in ds.Entries)
                {
                    WriteLine("Name : " + i.Name);
                }
            }
            using(ZipArchive zp= ZipFile.OpenRead("lasttesting.zip"))
            {
                var entry = zp.GetEntry("h33.txt");
                if (entry != null)
                {
                    using(StreamReader rx= new StreamReader(entry.Open()))
                    {
                        WriteLine(rx.ReadToEnd());
                    }
                }
            }
            using(ZipArchive xs= ZipFile.Open("lasttesting.zip", ZipArchiveMode.Update))
            {
                var entry = xs.CreateEntry("newFile.txt");
                using (StreamWriter sw = new StreamWriter(entry.Open()))
                {
                    sw.WriteLine("Hello Vishal ");
                }
            }


           





        }
        //Brotli 
        
        public void BrotliPrac()
        {
            using (FileStream fs = new FileStream("sk.br",FileMode.Create))
            using(BrotliStream bs= new BrotliStream(fs,CompressionMode.Compress))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                sw.Write("Hello Vishal Brotli version");
            }

            // decompress
            using (FileStream fs = new FileStream("sk.br", FileMode.Open))
            using (BrotliStream bs = new BrotliStream(fs, CompressionMode.Decompress))
            using (StreamReader sr = new StreamReader(bs))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }

    }
}
