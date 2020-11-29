﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiptReader.Models
{
    public class ReceiptModel
    {
        public string Language { get; set; }
        public double TextAngle { get; set; }
        public string Orientation { get; set; }
        public RegionModels[] Regions { get; set; }
        
    }
}