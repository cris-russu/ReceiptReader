using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptReader.Helpers
{
    public static class Testers
    {
        

        public async static Task ScanAllFolder()
        {
            int counter = 0;
            foreach (var imageFilePath in Helpers.PicturesPaths)
            {


                if (File.Exists(imageFilePath))
                {
                    counter++;
                    Console.WriteLine(Environment.NewLine + $"Image nr. {counter}");
                    Console.WriteLine($"Image {imageFilePath}");
                    // Call the REST API method.
                    Console.WriteLine("\nWait a moment for the results to appear.\n");
                    await Helpers.MakeOCRRequest(imageFilePath);
                }
                else
                {
                    Console.WriteLine("\nInvalid file path");
                }

            }
        }


       
        
    }
}
