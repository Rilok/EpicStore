﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._3Ram
{
    public abstract class Ram
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Amount { get; set; }
        public int MemorySize { get; set; }
        public int Clocking { get; set; }
        public int Price { get; set; }
    }
}
