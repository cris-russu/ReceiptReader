using IronOcr;
using System;
 

namespace IronTiif2PdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
            {
                Input.AddMultiFrameTiff(@"C:\Users\hrust\Downloads\pic 3.jpg");
                var Result = Ocr.Read(Input);

                Result.SaveAsSearchablePdf("searchable.pdf");
            }
        }
    }
}
