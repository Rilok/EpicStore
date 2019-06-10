using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._3Ram
{
    public interface IRamFactory
    {
        Ram TakeRam(int choice);
    }
}
