using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReceiptReader.Helpers;
using ReceiptReader.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSHttpClientSample
{
    static class Program
    {
       
        static async Task Main()
        {
            // Get the path and filename to process from the user.
            Console.WriteLine("Optical Character Recognition:");
            Console.Write("Enter the path to an image with text you wish to read: ");

            //string imageFilePath = Console.ReadLine();

            #region testing_Area  
            //string imageFilePath = @"C:\Users\hrust\Downloads\receipts\pic 6.jpg";
            //Console.ReadKey();

            await Testers.ScanAllFolder(); 

            #endregion testing_Area

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

      

       
    }
}