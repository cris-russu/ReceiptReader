namespace ReceiptReader.Models
{
    public class RegionModel
    {
        public string BoundingBox { get; set; }
        public LineModel[] Lines { get; set; }

        public CoordinatesModel BoundingCoordinates => Helpers.Helpers.GetCoordinates(BoundingBox);

    }
}