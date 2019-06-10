using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._1Motherboard
{
    public interface IMotherboardFactory
    {
        Motherboard TakeMotherboard(int choice);
    }
}
