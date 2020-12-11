using ReceiptReader.Logic;
using ReceiptReader.Models;
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


        public async static Task DisplayAllFolderInfo()
        {
            int counter = 0;
            foreach (var imageFilePath in Helpers.PicturesPaths)
            {
                counter++;
                Console.WriteLine(Environment.NewLine + $"Image nr. {counter}");
                DisplayPictureInfo(imageFilePath);
                await Task.Delay(2000);
            }
        }

        public static async void DisplayPictureInfo(string imageFilePath)
        {
            if (File.Exists(imageFilePath))
            {
                ReceiptProcessor proc = new ReceiptProcessor();
                await proc.ExtractReceipt(imageFilePath);

                DisplayModelRegions(proc.Receipt);
                foreach (var region in proc.Receipt.Regions)
                {
                    Helpers.GetTextFromRegion(region);
                }
            }
            else
            {
                Console.WriteLine("\nInvalid file path");
            }


        }

        internal static void DisplayModelRegions(dynamic model)
        {
            Console.WriteLine("language: " + model.Language);
            Console.WriteLine(model.Regions.Length + " regions");
            Helpers.DisplayRegionsCoordinates(model.Regions);
        }
    }
}
