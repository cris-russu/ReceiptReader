using ReceiptReader.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReceiptReader.Helpers
{
    public static class Helpers
    {
        private static string folderPath = @"C:\Users\hrust\Downloads\receipts";

        public static string[] PicturesPaths => Directory.GetFiles(folderPath);

        public static CoordinatesModel GetCoordinates(string input)
        {

            CoordinatesModel result = new CoordinatesModel();
            try
            {
                string[] _ = input.Split(',');
                if (_.Length >= 4)
                {
                    result.X = int.Parse(_[0]);
                    result.Y = int.Parse(_[1]);
                    result.DeltaX = int.Parse(_[2]);
                    result.DeltaY = int.Parse(_[3]);
                }
                else
                    Console.WriteLine("something wrong with the bounding box coordinates format");

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.ToString());
                throw;
            }
            return result;
        }

        public static void DisplayRegionsCoordinates(RegionModel[] regions)
        {
            int counter = 0;
            foreach (var region in regions)
            {
                counter++;
                Console.WriteLine($"Region{counter}: bounding coordinates {region.BoundingCoordinates}" + Environment.NewLine);
            }
        }

        public static void GetTextFromRegion(RegionModel region)
        {
            List<string> textList = new List<string>();
            Console.WriteLine($"Region coordinates: \n{region.BoundingCoordinates}");
            
            foreach (var line in region.Lines)
            {
                for (int i = 0; i < line.Words.Length; i++)
                {
                    textList.Add(line.Words[i].Text);
                   // Console.WriteLine(line.Words[i].Text);
                }
            }

        }

       
    
    }
}
