namespace ReceiptReader.Models
{
    public class WordModel
    {
        public string BoundingBox { get; set; }
        public string Text { get; set; }
        public CoordinatesModel BoundingCoordinates => Helpers.Helpers.GetCoordinates(BoundingBox);
    }
}