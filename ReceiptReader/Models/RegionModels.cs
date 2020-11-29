namespace ReceiptReader.Models
{
    public class RegionModels
    {
        public string BoundingBox { get; set; }
        public LineModel[] Lines { get; set; }

        public CoordinatesModel BoundingCoordinates => Helpers.Helpers.GetCoordinates(BoundingBox);

    }
}