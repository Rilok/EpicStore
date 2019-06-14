using System;
using EpicStore.Factory._2Processor;
using EpicStore.Factory._4GraphicsCard;

namespace EpicStore.Facade
{
    public class GraphSetup
    {
        public int ChooseGraph(Processor proc)
        {
            IGraphicsFactory factory;
            if (proc.Manufacturer == "Intel")
                factory = AmdGraphFactory.Instance;
            else
                factory = NvidiaGraphFactory.Instance;

            int x = 1;
            Console.WriteLine("Wybierz kartę graficzną.\n\n");

            while (factory.TakeGraphicsCard(x) != null)
            {
                Console.WriteLine($"#{x}: \n{factory.TakeGraphicsCard(x)}");
                x++;
            }
            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 4)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChooseGraph(proc);
            }

            return choose;
        }
    }
}