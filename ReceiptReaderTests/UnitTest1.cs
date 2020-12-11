using NUnit.Framework;
using ReceiptReader.Logic;
using ReceiptReader.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptReaderTests
{
    public class Tests
    {
        string imageFilePath = @"C:\Users\hrust\Downloads\receipts\IMG_1312.jpg";
        ReceiptModel rP = new ReceiptModel();

        [SetUp]
        public void Setup()
        {
            ReceiptProcessor recProc = new ReceiptProcessor();

            Task.Run(async () =>
            {
                await recProc.ExtractReceipt(imageFilePath);
            }).GetAwaiter().GetResult();

            rP = recProc.Receipt;
        }

        [Test]
        public void NoOfRegionsTest()
        {
            //Arrange
            int expectedNoOfRegions = 5;
           
            //Act
            int actualNoOfRegions = rP.Regions.Length;

            //Assert
            Assert.AreEqual(expectedNoOfRegions, actualNoOfRegions);
        }

        [Test]
        public void NoOfLinesTest()
        {
            //Arrange
            int expectedNoOfLines = 53;

            //Act
            var actualNoOfLines = rP.Regions.SelectMany(r => r.Lines).Select(l => l).ToList().Count;

            //Assert
            Assert.AreEqual(expectedNoOfLines, actualNoOfLines);
        }
    }
}