using System;
using EpicStore.Builder;
using EpicStore.Facade;
using EpicStore.Factory._1Motherboard;
using EpicStore.Factory._2Processor;
using EpicStore.Factory._3Ram;
using EpicStore.Factory._5HardDrive;
using EpicStore.Factory._6PowerAdapter;
using EpicStore.Iterator;
using EpicStore.Strategy;

namespace EpicStore
{
    class Program
    {
        public static int mother, proc, ram, graph, hard, power;
        public static string graphChoice, driveChoice;
        static void Main(string[] args)
        {
            int choose;
            int chooseComputer;

            Motherboard tmpMother;
            Processor tmpProc;

            var epicCompany = new EpicCompany();
            CompCollection computerList = new CompCollection();

            Iterator.Iterator iterator = computerList.CreateIterator();

            //INIT LIST
            computerList[0] = epicCompany.Build(new LowEndBuilder(1, 1, 1, 1, 1, 1, "nVidia", "SSD"));
            computerList[1] = epicCompany.Build(new LowEndBuilder(1, 2, 1, 2, 2, 3, "AMD", "HDD"));
            computerList[2] = epicCompany.Build(new LowEndBuilder(3, 2, 2, 2, 1, 3, "nVidia", "SSD"));

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
                        tmpMother = MotherboardFactory.Instance.TakeMotherboard(mother);

                        proc = ChooseProcessor(mother);
                        tmpProc = ProcessorFactory.Instance.TakeProcessor(tmpMother.Socket, proc);

                        ram = ChooseRam();
                        ChooseGraphHard(tmpProc);
                        power = ChoosePower();
                            
                        computerList.Add(epicCompany.Build(new LowEndBuilder(mother, proc, ram, graph, hard, power, "AMD", "SSD")));

                        //iterator.Step = 2;

                        Console.Clear();
                        break;
                    }

                    case 2:
                    {
                        Console.WriteLine("Wpisz numer swojego komputera: ");
                        chooseComputer = Convert.ToInt32(Console.ReadLine()) - 1;

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
                            Console.WriteLine($"\n#{iterator.Curr + 1}\n");
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

        static void ChooseGraphHard(Processor proc)
        {
            Console.Clear();
            Console.WriteLine("Jaką chcesz wersję?");
            Console.WriteLine("1. W pełni optymalna.");
            Console.WriteLine("2. Optymalna pod grafikę.");
            Console.WriteLine("3. Optymalna pod dysk.");
            Console.WriteLine("4. Bez optymalizacji.");

            int choice = Convert.ToInt32(Console.ReadLine()); 
            
            Console.Clear();
            FacadeSetup setUp = new FacadeSetup();

            switch (choice)
            {
                case 1:
                {
                    setUp.OptimalChoice(proc);
                    SetOptGraphChoice(proc);
                    driveChoice = "SSD";
                    break;
                }

                case 2:
                {
                    setUp.GraphOptimalChoice(proc);
                    SetOptGraphChoice(proc);
                    driveChoice = "HDD";
                    break;
                }

                case 3:
                {
                    setUp.DriveOptimalChoice(proc);
                    SetGraphChoice(proc);
                    driveChoice = "SSD";
                    break;
                }

                case 4:
                {
                    setUp.Choice(proc);
                    SetGraphChoice(proc);
                    driveChoice = "HDD";
                    break;
                }
            }

            graph = setUp.graph;
            hard = setUp.drive;

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

        static void SetOptGraphChoice(Processor proc)
        {
            if (proc.Manufacturer == "Intel")
                graphChoice = "nVidia";
            else
                graphChoice = "AMD";
        }

        static void SetGraphChoice(Processor proc)
        {
            if (proc.Manufacturer == "Intel")
                graphChoice = "AMD";
            else
                graphChoice = "nVidia";
        }
    }
}
