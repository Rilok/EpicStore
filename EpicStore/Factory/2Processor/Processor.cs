using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._2Processor
{
    public abstract class Processor
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Socket { get; set; }
        public int Cores { get; set; }
        public double MinClocking { get; set; }
        public double MaxClocking { get; set; }
        public int Price { get; set; }
    }
}
