using System;
using EpicStore.Builder;
using EpicStore.Iterator;

namespace EpicStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompCollection comps = new CompCollection();
            Builder.Computer builderComputer;
            var epicCompany = new EpicCompany();

            //comps[0] = epicCompany.Build(new LowEndBuilder(1, 2, 1, 3, 2, 3, "AMD", "SSD"));


            builderComputer = epicCompany.Build(new LowEndBuilder(1, 2, 1, 3, 2, 3, "AMD", "SSD"));

            PrintData(builderComputer);
            
        }

        static void PrintData(Computer computer)
        {
            Console.WriteLine("Built new computer!");
            Console.WriteLine("Motherboard: ");
            Console.WriteLine($"Manufacturer: {computer.Motherboard.Manufacturer}");
            Console.WriteLine($"Model: {computer.Motherboard.Model}");
            Console.WriteLine($"Type: {computer.Motherboard.Type}");
            Console.WriteLine($"Chipset: {computer.Motherboard.Chipset}");
            Console.WriteLine($"Socket: {computer.Motherboard.Socket}");

            Console.WriteLine("\nProcessor:");
            Console.WriteLine($"Manufacturer: {computer.Processor.Manufacturer}");
            Console.WriteLine($"Model: {computer.Processor.Model}");
            Console.WriteLine($"Socket: {computer.Processor.Socket}");
            Console.WriteLine($"Number of Cores: {computer.Processor.Cores}");
            Console.WriteLine($"Clocks range: {computer.Processor.MinClocking} - {computer.Processor.MaxClocking}");

            Console.WriteLine("\nRAM: ");
            Console.WriteLine($"Manufacturer: {computer.Ram.Manufacturer}");
            Console.WriteLine($"Model: {computer.Ram.Model}");
            Console.WriteLine($"Chips amount: {computer.Ram.Amount}");
            Console.WriteLine($"Memory size: {computer.Ram.MemorySize}");
            Console.WriteLine($"Clocking: {computer.Ram.Clocking}");

            Console.WriteLine("\nGraphics Card: ");
            Console.WriteLine($"Manufacturer: {computer.GraphicsCard.Manufacturer}");
            Console.WriteLine($"Model: {computer.GraphicsCard.Model}");
            Console.WriteLine($"VideoRAM size: {computer.GraphicsCard.VideoMemorySize}");

            Console.WriteLine("\nHard Drive: ");
            Console.WriteLine($"Manufacturer: {computer.HardDrive.Manufacturer}");
            Console.WriteLine($"Model: {computer.HardDrive.Model}");
            Console.WriteLine($"Type: {computer.HardDrive.Type}");
            Console.WriteLine($"Capacity: {computer.HardDrive.Capacity}");

            Console.WriteLine("\nPower Adapter: ");
            Console.WriteLine($"Manufacturer: {computer.PowerAdapter.Manufacturer}");
            Console.WriteLine($"Model: {computer.PowerAdapter.Model}");
            Console.WriteLine($"Power: {computer.PowerAdapter.Power}");

            Console.WriteLine($"Overall price: {computer.Price}");
        }
    }
}
