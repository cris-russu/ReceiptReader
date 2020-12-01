using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptReader.Models
{
    public class CoordinatesModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, DeltaX: {DeltaX}, DeltaY: {DeltaY}";
        }
    }
}
