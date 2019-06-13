using EpicStore.Factory._2Processor;

namespace EpicStore.Strategy
{
    public abstract class ProcStrategy
    {
        public abstract int ChooseProcessor(ProcessorFactory processorFactory);
    }
}