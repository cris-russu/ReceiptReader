using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReceiptReader.Helpers;
using ReceiptReader.Logic;
using ReceiptReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSHttpClientSample
{
    static class Program
    {

        static async Task Main()
        {
            string imageFilePath = @"C:\Users\hrust\Downloads\receipts\IMG_1312.jpg";
            Testers.DisplayPictureInfo(imageFilePath);

            ReceiptProcessor recProc = new ReceiptProcessor();
            await recProc.ExtractReceipt(imageFilePath);
           

            //TODO: add processor-classes for line- and receipt-models
            //TODO: improve the mapping of the Total/Sum/At betale field to the sum 

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }




    }
}