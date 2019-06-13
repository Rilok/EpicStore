using EpicStore.Factory._2Processor;

namespace EpicStore.Strategy
{
    public class InitProcFactory
    {
        private ProcessorFactory _processorFactory = ProcessorFactory.Instance;
        private ProcStrategy _procStrategy;

        public void SetProcStrategy(ProcStrategy procStrategy)
        {
            this._procStrategy = procStrategy;
        }

        public int ChooseProcessor()
        {
            return _procStrategy.ChooseProcessor(_processorFactory);
        }
    }
}