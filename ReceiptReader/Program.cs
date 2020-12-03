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
            string imageFilePath = @"C:\Users\hrust\Downloads\receipts\pic 6.jpg";
          //  await Testers.DisplayPictureInfo(imageFilePath);

            ReceiptModel receipt = await Helpers.MakeOCRRequest(imageFilePath);

            //  Helpers.FindTotalCoordinates(model);
            //            Helpers.DisplayAvgLineHeight(model);

            ReceiptProcessor recProc = new ReceiptProcessor(receipt);
            recProc.FindTotalSum();

            //TODO: add processor-classes for line- and receipt-models
           

            //await Testers.DisplayAllFolderInfo();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }




    }
}