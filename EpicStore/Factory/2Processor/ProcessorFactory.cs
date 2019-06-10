using System;
using EpicStore.Factory._2Processor.AMDStuff;
using EpicStore.Factory._2Processor.IntelStuff;

namespace EpicStore.Factory._2Processor
{
    public class ProcessorFactory : IProcessorFactory
    {
        private static readonly Lazy<ProcessorFactory> _mothInstance =
            new Lazy<ProcessorFactory>(() => Activator
                    .CreateInstance(typeof(ProcessorFactory), true)
                as ProcessorFactory);
        private ProcessorFactory() { }

        public static ProcessorFactory Instance
        {
            get { return _mothInstance.Value; }
        }

        public Processor TakeProcessor(string brand, int choice)
        {
            switch (brand)
            {
                case "Intel":
                {
                    switch (choice)
                    {
                        case 1: return new IntelProc1();
                        case 2: return new IntelProc2();
                        default: return new IntelProc3();
                    }
                }

                case "AMD":
                {
                    switch (choice)
                    {
                        case 1: return new AmdProc1();
                        case 2: return new AmdProc2();
                        default: return new AmdProc3();
                    }
                }

                default:
                {
                    return null;
                }
            }
        }
    }
}