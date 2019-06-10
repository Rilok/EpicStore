using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Builder
{
    class EpicCompany
    {
        public Computer Build(ComputerBuilder computer)
        {
            return computer;
        }
    }
}
