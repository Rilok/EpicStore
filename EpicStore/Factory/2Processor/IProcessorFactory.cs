using System;
using System.Collections.Generic;
using System.Text;

namespace EpicStore.Factory._2Processor
{
    public interface IProcessorFactory
    {
        Processor TakeProcessor(string brand, int choice);
    }
}
