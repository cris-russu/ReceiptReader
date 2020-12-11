namespace ReceiptReader.Models
{
    public class LineModel
    {
        public string BoundingBox { get; set; }
        public WordModel[] Words { get; set; }
        public CoordinatesModel BoundingCoordinates => Helpers.Helpers.GetCoordinates(BoundingBox);
    }
}
