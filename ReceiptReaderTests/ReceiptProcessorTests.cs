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
        ReceiptModel rM = new ReceiptModel();
        ReceiptProcessor recProc = new ReceiptProcessor();

        [SetUp]
        public void Setup()
        {

            Task.Run(async () =>
            {
                await recProc.ExtractReceipt(imageFilePath);
            }).GetAwaiter().GetResult();

            rM = recProc.Receipt;
        }

        [Test]
        public void NoOfRegionsTest()
        {
            //Arrange
            int expectedNoOfRegions = 5;

            //Act
            int actualNoOfRegions = rM.Regions.Length;

            //Assert
            Assert.AreEqual(expectedNoOfRegions, actualNoOfRegions);
        }

        [Test]
        public void NoOfLinesTest()
        {
            //Arrange
            int expectedNoOfLines = 53;

            //Act
            var actualNoOfLines = rM.Regions.SelectMany(r => r.Lines).Select(l => l).ToList().Count;

            //Assert
            Assert.AreEqual(expectedNoOfLines, actualNoOfLines);
        }

        [Test]
        public void ExtractAllLinesTest()
        {
            //Arrange
            int expectedNoOfLines = 53;

            //Act
            var actualNoOfLines = recProc.ExtractAllLines().Count;

            //Assert
            Assert.AreEqual(expectedNoOfLines, actualNoOfLines);

        }
    }
}