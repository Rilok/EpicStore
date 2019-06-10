using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._1Motherboard.Stuff
{
    class Mother2 : Motherboard
    {
        public Mother2()
        {
            Manufacturer = "Gigabyte";
            Model = "Z370P D3";
            Type = "ATX";
            Chipset = "Intel Z370";
            Socket = "1151";
            Price = 469;
        }
    }
}
