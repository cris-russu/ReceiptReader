using ReceiptReader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptReader.Logic
{
    public class ReceiptProcessor
    {
        private ReceiptModel _receipt;

        public ReceiptModel Receipt
        {
            get { return _receipt; }
            set { _receipt = value; }
        }

        public async Task<ReceiptModel> ExtractReceipt(string imageFilePath)
        {
            if (File.Exists(imageFilePath))
            {
                Console.WriteLine($"Image {imageFilePath}");
                Console.WriteLine("\nWait a moment for the results to appear.\n");
                _receipt = await Helpers.Helpers.MakeOCRRequest(imageFilePath);
            }
            else
            {
                Console.WriteLine("\nInvalid file path");
                _receipt = new ReceiptModel();
            }
            return _receipt;
        }

        

        public ReceiptProcessor(ReceiptModel receipt)
        {
            _receipt = receipt;
        }

        public ReceiptProcessor()
        {
        }

        public List<LineModel> ExtractAllLines()
        {
            List<LineModel> allLines = new List<LineModel>();

            foreach (var region in Receipt.Regions)
            {
                var res = region.Lines.Select(l => l);
                foreach (var item in res)
                {
                    allLines.Add(item);
                }
            }

            return allLines;
        }

        //TODO: finish this
        public void MergeLineText()
        {
            var allLines = ExtractAllLines();

            foreach (var line in allLines)
            {
                var res = line.Words.Select(w => w.Text);
                string temp = "";
                foreach (var word in res)
                {
                    temp = word + " ";
                    Console.Write(temp);
                }
                Console.WriteLine();
            }
        }

        public void FindTotalSum()
        {
            var allLines = ExtractAllLines();

            CoordinatesModel totalCoord = Helpers.Helpers.FindTotalCoordinates(Receipt);

            int avgLineHeight = (int)Helpers.Helpers.DisplayAvgLineHeight(Receipt).Average();

            var res = allLines.Select(l => l)
                              .Where(line => (line.BoundingCoordinates.Y < totalCoord.Y + avgLineHeight) && (line.BoundingCoordinates.Y >= totalCoord.Y - avgLineHeight));

            foreach (var line in res)
            {
                var txt = line.Words.SelectMany(w => w.Text)
                                    .Select(t => t);
                foreach (var item in txt)
                {
                    Console.Write(item + " ");

                }
                Console.WriteLine();
            }
        }

    }
}
