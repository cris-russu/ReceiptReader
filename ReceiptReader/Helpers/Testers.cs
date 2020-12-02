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
                await DisplayPictureInfo(imageFilePath);
                await Task.Delay(2000);
            }
        }

        public  async static Task DisplayPictureInfo(string imageFilePath)
        {
            if (File.Exists(imageFilePath))
            {                
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

        internal static void DisplayModelRegions(dynamic model)
        {
            Console.WriteLine("language: " + model.Language);
            Console.WriteLine(model.Regions.Length + " regions");
            Helpers.DisplayRegionsCoordinates(model.Regions);
        }
    }
}
