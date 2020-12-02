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
            //string imageFilePath = @"C:\Users\hrust\Downloads\receipts\pic 6.jpg";
            //await Testers.GetPictureInfo(imageFilePath);
            
            
            await Testers.DisplayAllFolderInfo();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }




    }
}