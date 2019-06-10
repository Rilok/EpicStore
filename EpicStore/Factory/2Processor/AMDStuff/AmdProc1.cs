namespace EpicStore.Factory._2Processor.AMDStuff
{
    public class AmdProc1 : Processor
    {
        public AmdProc1()
        {
            Manufacturer = "AMD";
            Model = "Ryzen 5 2600";
            Socket = "AM4";
            Cores = 6;
            MinClocking = 3.4;
            MaxClocking = 3.9;
            Price = 669;
        }
    }
}