using System;
using System.Collections.Generic;
using EpicStore.Builder;
using EpicStore.Factory._1Motherboard;
using EpicStore.Factory._1Motherboard.Stuff;
using EpicStore.Factory._2Processor;
using EpicStore.Factory._2Processor.AMDStuff;
using EpicStore.Factory._2Processor.IntelStuff;
using EpicStore.Factory._3Ram;
using EpicStore.Factory._3Ram.Stuff;
using EpicStore.Factory._4GraphicsCard;
using EpicStore.Factory._4GraphicsCard.AMDStuff;
using EpicStore.Factory._4GraphicsCard.nVidiaStuff;
using EpicStore.Factory._5HardDrive;
using EpicStore.Factory._5HardDrive.HddStuff;
using EpicStore.Factory._5HardDrive.SsdStuff;
using EpicStore.Factory._6PowerAdapter;
using EpicStore.Factory._6PowerAdapter.Stuff;
using EpicStore.Iterator;
using EpicStore.Strategy;

namespace EpicStore
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose;
            int chooseComputer;

            int mother, proc, ram, graph, hard, power;

            
            GraphicsFactory graphicsFactory = GraphicsFactory.Instance;
            HardDriveFactory hardDriveFactory = HardDriveFactory.Instance;



            Builder.Computer builderComputer;
            var epicCompany = new EpicCompany();
            CompCollection computerList = new CompCollection();

            Iterator.Iterator iterator = computerList.CreateIterator();

            Console.WriteLine("Witaj w sklepie komputerowym!");

            do
            {
                Console.WriteLine("Co chcesz zrobić? ");
                Console.WriteLine("1. Zbuduj nowy komputer!");
                Console.WriteLine("2. Pokaż specyfikację komputera.");
                Console.WriteLine("3. Pokaż wszystkie komputery.");
                Console.WriteLine("4. Wyjdź.");

                choose = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (choose)
                {
                    case 1:
                    {
                        mother = ChooseMotherboard();
                        proc = ChooseProcessor(mother);
                        ram = ChooseRam();
                        //graph = ChooseGraph();
                        //hard = ChooseHardDrive();
                        power = ChoosePower();

                        builderComputer = epicCompany.Build(new LowEndBuilder(1, 2, 1, 2, 2, 3, "AMD", "SSD"));
                        

                        computerList[0] = epicCompany.Build(new LowEndBuilder(mother, proc, ram, 2, 2, power, "AMD", "SSD"));
                        computerList[1] = epicCompany.Build(new LowEndBuilder(1, 2, 1, 2, 2, 3, "AMD", "SSD"));
                        computerList[2] = epicCompany.Build(new LowEndBuilder(1, 2, 1, 2, 2, 3, "AMD", "SSD"));
                        computerList[3] = epicCompany.Build(new LowEndBuilder(1, 2, 1, 2, 2, 3, "AMD", "SSD"));

                        //iterator.Step = 2;

                        Console.Clear();
                        break;
                    }

                    case 2:
                    {
                        Console.WriteLine("Wpisz numer swojego komputera: ");
                        chooseComputer = Convert.ToInt32(Console.ReadLine());

                        iterator.Curr = chooseComputer;
                        Console.Clear();

                        PrintData(iterator.GetCurrent);
                        Console.WriteLine("\nNaciśnij dowolny klawisz...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    case 3:
                    {
                        Console.WriteLine("Lista wszystkich komputerów.\n\n");
                        for (Computer computer = iterator.First();
                            !iterator.IsDone;
                            computer = iterator.Next())
                        {
                            Console.WriteLine("#1\n");
                            PrintData(computer);
                        }
                        Console.WriteLine("\nNaciśnij dowolny klawisz...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    default: break;
                }
            } while (choose != 4);
        }

        static void MakeChoice()
        {
            Console.WriteLine("Jaki podzespół chcesz wymienić?");
            Console.WriteLine("1. Płyta główna.");
            Console.WriteLine("2. Procesor");
            Console.WriteLine("3. RAM.");
            Console.WriteLine("4. Karta Graficzna.");
            Console.WriteLine("5. Dysk twardy.");
            Console.WriteLine("6. Zasilacz.");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine("Wybierz podzespół.");
                    
                    break;
                }
            }
        }

        static void PrintData(Computer computer)
        {
            Console.WriteLine($"{computer.Motherboard}\n");
            Console.WriteLine($"{computer.Processor}\n");
            Console.WriteLine($"{computer.Ram}\n");
            Console.WriteLine($"{computer.GraphicsCard}\n");
            Console.WriteLine($"{computer.HardDrive}\n");
            Console.WriteLine($"{computer.PowerAdapter}\n");
            Console.WriteLine($"Cena zestawu: {computer.Price} zł");
        }

        static int ChooseMotherboard()
        {
            MotherboardFactory motherboardFactory = MotherboardFactory.Instance;

            int x = 1;
            Console.Clear();
            Console.WriteLine("Wybierz płytę główną.\n\n");

            while (motherboardFactory.TakeMotherboard(x) != null)
            {
                Console.WriteLine($"#{x}: \n{motherboardFactory.TakeMotherboard(x)}");
                x++;
            }

            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 4)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChooseMotherboard();
            }

            return choose;
        }

        static int ChooseProcessor(int motherChoice)
        {
            MotherboardFactory motherboardFactory = MotherboardFactory.Instance;
            InitProcFactory procFactory = new InitProcFactory();

            Console.Clear();
            Console.WriteLine("Wybierz procesor.\n\n");

            if (motherboardFactory.TakeMotherboard(motherChoice).Socket == "1151")
            {
                procFactory.SetProcStrategy(new IntelProc());
            }

            else if (motherboardFactory.TakeMotherboard(motherChoice).Socket == "AM4")
            {
                procFactory.SetProcStrategy(new AmdProc());
            }
            
            return procFactory.ChooseProcessor();
        }



        static int ChooseRam()
        {
            RamFactory ramFactory = RamFactory.Instance;

            int x = 1;
            Console.Clear();
            Console.WriteLine("Wybierz wariant pamięci RAM.\n\n");

            while (ramFactory.TakeRam(x) != null)
            {
                Console.WriteLine($"#{x}: \n{ramFactory.TakeRam(x)}");
                x++;
            }

            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 4)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChooseRam();
            }

            return choose;
        }

        static int ChoosePower()
        {
            PowerFactory powerFactory = PowerFactory.Instance;

            int x = 1;
            Console.Clear();
            Console.WriteLine("Wybierz zasilacz.\n\n");

            while (powerFactory.TakePowerAdapter(x) != null)
            {
                Console.WriteLine($"#{x}: \n{powerFactory.TakePowerAdapter(x)}");
                x++;
            }

            int choose = Convert.ToInt32(Console.ReadLine());
            if (0 >= choose || choose >= 4)
            {
                Console.WriteLine("Podałeś zły wariant.");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey();
                ChoosePower();
            }

            return choose;
        }
    }
}
