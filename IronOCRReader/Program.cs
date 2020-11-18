using System;
using System.IO;
using IronOcr;


namespace IronOCRReader
{
    class Program
    {
        static void Main(string[] args)
        {

            var Result = new IronTesseract().Read(@"C:\Users\hrust\Downloads\pic 3.jpg");
            File.WriteAllText(@"C:\Users\hrust\Downloads\temp_text.txt", Result.Text);
            
            Console.WriteLine(Result.Text);

        }
    }
}
