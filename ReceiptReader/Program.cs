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
            string imageFilePath = @"C:\Users\hrust\Downloads\receipts\IMG_1306.jpg";

            Helpers.DisplayJSONResponse(await Helpers.MakeOCRRequest(imageFilePath));

            ReceiptProcessor recProc = new ReceiptProcessor();
            await recProc.ExtractReceipt(imageFilePath);

            
            //recProc.MergeLineText();
            //foreach (var line in recProc.MergedLines)
            //{
            //    Console.WriteLine(line);
            //}

            //TODO: improve the mapping of the Total/Sum/At betale field to the sum 

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }




    }
}