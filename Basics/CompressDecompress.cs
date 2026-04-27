

using System.IO.Compression;

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

            using (FileStream cfd= new FileStream("CompressedFile.gz",FileMode.Open))
            using(GZipStream gzd= new GZipStream(cfd,CompressionMode.Decompress))
            using(StreamReader sdd = new StreamReader(gzd))
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
            byte[] datab= Encoding.UTF8.GetBytes(Texta);
            using (FileStream fsq = new FileStream("raw.gz", FileMode.Create))
            using (GZipStream NewGzip = new GZipStream(fsq, CompressionMode.Compress))
            {
                NewGzip.Write(datab);

            } 
            //Decompression

            using(FileStream fsd = new FileStream("raw.gz",FileMode.Open))
            
            using(GZipStream DNewZip= new GZipStream(fsd, CompressionMode.Decompress))
            using(MemoryStream ms= new MemoryStream())
            {
                DNewZip.CopyTo(ms);
                ms.Position = 0;
                byte[] data11=ms.ToArray();
                string resultDec = Encoding.UTF8.GetString(data11);
                //File.WriteAllText("DecompressedFile.txt", resultDec);
                WriteLine(resultDec);

            }

        }
        public void ziprac()
        {
            string sourceFolder = "dpracticefolder";
            string newZip = "dpracticefolder.zip";
            string extract = "OpFolderNew";

            try
            {
                // check folder exist
                if (!Directory.Exists(sourceFolder))
                {
                    WriteLine("Source folder nahi mila ❌");
                    return;
                }

                // delete old zip
                if (File.Exists(newZip))
                {
                    File.Delete(newZip);
                }

                // 1. Create Zip
                ZipFile.CreateFromDirectory(sourceFolder, newZip);
                WriteLine("Zip folder created");

                // 2. Unzip
                if (Directory.Exists(extract))
                {
                    Directory.Delete(extract, true);
                }

                ZipFile.ExtractToDirectory(newZip, extract);
                WriteLine("Unzip ho gaya");

                // 3. Read
                using (ZipArchive zx = ZipFile.OpenRead(newZip))
                {
                    WriteLine("Zip ke andar files:");
                    foreach (var i in zx.Entries)
                    {
                        WriteLine(i.Name);
                    }
                }
               
            }
            catch (Exception ex)
            {
                WriteLine("Error: " + ex.Message);
            }
        }

    }
}
