using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReceiptReader.Helpers;
using ReceiptReader.Models;
using System;
using System.Collections.Generic;
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
            string imageFilePath = @"C:\Users\hrust\Downloads\receipts\IMG_1313.jpg";
            await Testers.DisplayPictureInfo(imageFilePath);

            ReceiptModel model = await Helpers.MakeOCRRequest(imageFilePath);

            //  Helpers.FindTotalCoordinates(model);
            //            Helpers.DisplayAvgLineHeight(model);

            List<LineModel> lines =  Helpers.ExtractAllLines(model);

            //TODO: add processor-classes for line- and receipt-models
            //TODO: add method to map word "TOTAL" to  actual total sum on receipt

            //await Testers.DisplayAllFolderInfo();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }




    }
}