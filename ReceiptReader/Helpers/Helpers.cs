using Newtonsoft.Json;
using ReceiptReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

namespace ReceiptReader.Helpers
{
    public static class Helpers
    {
        private static string folderPath = @"C:\Users\hrust\Downloads\receipts";

        static string subscriptionKey = Environment.GetEnvironmentVariable("COMPUTER_VISION_SUBSCRIPTION_KEY");

        static string endpoint = Environment.GetEnvironmentVariable("COMPUTER_VISION_ENDPOINT");

        // the OCR method endpoint
        static string uriBase = endpoint + "vision/v2.1/ocr";


        /// <summary>
        /// Returns the contents of the specified file as a byte array.
        /// </summary>
        /// <param name="imageFilePath">The image file to read.</param>
        /// <returns>The byte array of the image data.</returns>
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            // Open a read-only file stream for the specified file.
            using FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            // Read the file's contents into a byte array.
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        /// <summary>
        /// Gets the text visible in the specified image file by using
        /// the Computer Vision REST API.
        /// </summary>
        /// <param name="imageFilePath">The image file with printed text.</param>
        public static async Task<ReceiptModel> MakeOCRRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Request headers.
                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", subscriptionKey);

                // Request parameters. 
                // The language parameter doesn't specify a language, so the 
                // method detects it automatically.
                // The detectOrientation parameter is set to true, so the method detects and
                // and corrects text orientation before detecting text.
                string requestParameters = "language=unk&detectOrientation=true";

                // Assemble the URI for the REST API method.
                string uri = uriBase + "?" + requestParameters;

                HttpResponseMessage response;

                // Read the contents of the specified local image
                // into a byte array.
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                // Add the byte array as an octet stream to the request body.
                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses the "application/octet-stream" content type.
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    // Asynchronously call the REST API method.
                    response = await client.PostAsync(uri, content);
                }

                // Asynchronously get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();

                // Attempting to deserialize and contain JSON into new dynamic object
                return JsonConvert.DeserializeObject<ReceiptModel>(contentString);


                // Display the JSON response.
                //Console.WriteLine("\nResponse:\n\n{0}\n",
                //   JToken.Parse(contentString).ToString());
                // File.WriteAllText(@"C:\Users\hrust\Downloads\temp_text2.txt", JToken.Parse(contentString).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
                return null;
            }
        }

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
                    Console.WriteLine(line.Words[i].Text + $"            {line.Words[i].BoundingCoordinates}");
                }
            }

        }

        public static CoordinatesModel FindTotalCoordinates(ReceiptModel receipt)
        {
            CoordinatesModel coord = new CoordinatesModel();
            foreach (var region in receipt.Regions)
            {
                var coordinates = region.Lines.SelectMany(l => l.Words)
                                    .Select(w => w)
                                    .Where(t => t.Text == "TOTAL")
                                    .Select(s => s.BoundingCoordinates)
                                    .FirstOrDefault();
                if (coordinates != null) coord = coordinates;
                else continue;
            }
            return coord;
        }

        public static List<double> DisplayAvgLineHeight(ReceiptModel receipt)
        {
            List<List<int>> heights = new List<List<int>>();
            foreach (var region in receipt.Regions)
            {
                heights.Add(region.Lines.Select(l => l.BoundingCoordinates.DeltaY).ToList());
            }
            List<double> avgList = new List<double>();
            foreach (var list in heights)
            {
                avgList.Add(list.Average());
            }
            return avgList;
        }





    }
}
