namespace EpicStore.Factory._2Processor.IntelStuff
{
    public class IntelProc1 : Processor
    {
        public IntelProc1()
        {
            Manufacturer = "Intel";
            Model = "Core i5-9400F";
            Socket = "1151";
            Cores = 6;
            MinClocking = 2.9;
            MaxClocking = 4.1;
            Price = 709;
        }
    }
}