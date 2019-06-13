using System;
using EpicStore.Factory._2Processor;

namespace EpicStore.Strategy
{
    public class IntelProc : ProcStrategy
    {
        public override int ChooseProcessor(ProcessorFactory processorFactory)
        {
            int x = 1;
            Console.WriteLine("Wybierz procesor.\n\n");

            while (processorFactory.TakeProcessor("Intel", x) != null)
            {
                Console.WriteLine($"#{x}: \n{processorFactory.TakeProcessor("Intel", x)}");
                x++;
            }
            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 4)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChooseProcessor(processorFactory);
            }

            return choose;
        }
    }
}