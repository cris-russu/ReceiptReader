using ReceiptReader.Models;
using System;
using System.Collections.Generic;

namespace ReceiptReader.Helpers
{
    public static class Helpers
    {

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

        public static void DisplayRegionsCoordinates(RegionModels[] regions)
        {
            int counter = 0;
            foreach (var region in regions)
            {
                counter++;
                Console.WriteLine($"Region{counter}: bounding coordinates {region.BoundingCoordinates}" + Environment.NewLine);
            }
        }

        public static void GetTextFromRegion(RegionModels region)
        {
            List<string> textArray = new List<string>();
            foreach (var line in region.Lines)
            {
                for (int i = 0; i < line.Words.Length; i++)
                {
                    textArray.Add(line.Words[i].Text);
                }
            }

            foreach (var item in textArray)
            {
                Console.WriteLine(item);
            }
        }

    }
}
