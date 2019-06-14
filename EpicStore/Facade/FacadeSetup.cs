using EpicStore.Factory._2Processor;

namespace EpicStore.Facade
{
    public class FacadeSetup

    {
        private DriveSetup _driveSetup;
        private GraphSetup _graphSetup;
        private OptimalDriveSetup _optimalDriveSetup;
        private OptimalGraphSetup _optimalGraphSetup;

        public int graph { get; set; }
        public int drive { get; set; }
        public string graphChoose { get; set; }

        public FacadeSetup()
        {
            _driveSetup = new DriveSetup();
            _graphSetup = new GraphSetup();
            _optimalDriveSetup = new OptimalDriveSetup();
            _optimalGraphSetup = new OptimalGraphSetup();
        }

        public void OptimalChoice(Processor proc)
        {
            graph = _optimalGraphSetup.ChooseOptimalGraph(proc);
            drive = _optimalDriveSetup.ChooseOptimalDrive();
        }

        public void GraphOptimalChoice(Processor proc)
        {
            graph = _optimalGraphSetup.ChooseOptimalGraph(proc);
            drive = _driveSetup.ChooseDrive();
        }

        public void DriveOptimalChoice(Processor proc)
        {
            graph = _graphSetup.ChooseGraph(proc);
            drive = _optimalDriveSetup.ChooseOptimalDrive();
        }

        public void Choice(Processor proc)
        {
            graph = _graphSetup.ChooseGraph(proc);
            drive = _driveSetup.ChooseDrive();
        }
    }
}