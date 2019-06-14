using System;
using EpicStore.Factory._2Processor.AMDStuff;
using EpicStore.Factory._2Processor.IntelStuff;
using EpicStore.Strategy;

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

        public Processor TakeProcessor(string socket, int choice)
        {
            switch (socket)
            {
                case "1151":
                {
                    switch (choice)
                    {
                        case 1: return new IntelProc1();
                        case 2: return new IntelProc2();
                        case 3: return new IntelProc3();
                        default: return null;
                    }
                }

                case "AM4":
                {
                    switch (choice)
                    {
                        case 1: return new AmdProc1();
                        case 2: return new AmdProc2();
                        case 3: return new AmdProc3();
                        default: return null;
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