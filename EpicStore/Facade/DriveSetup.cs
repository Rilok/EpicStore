using System;
using EpicStore.Factory._5HardDrive;

namespace EpicStore.Facade
{
    public class DriveSetup
    {
        public int ChooseDrive()
        {
            HDDFactory factory = HDDFactory.Instance;

            int x = 1;
            Console.WriteLine("Wybierz procesor.\n\n");

            while (factory.TakeHardDrive(x) != null)
            {
                Console.WriteLine($"#{x}: \n{factory.TakeHardDrive(x)}");
                x++;
            }
            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 3)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChooseDrive();
            }

            return choose;
        }
    }
}