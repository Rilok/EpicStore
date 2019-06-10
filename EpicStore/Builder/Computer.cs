using System;
using EpicStore.Factory;
using EpicStore.Factory._1Motherboard;
using EpicStore.Factory._2Processor;
using EpicStore.Factory._3Ram;
using EpicStore.Factory._4GraphicsCard;
using EpicStore.Factory._5HardDrive;
using EpicStore.Factory._6PowerAdapter;

namespace EpicStore.Builder
{
    public class Computer
    {
        public Motherboard Motherboard { get; set; }
        public Processor Processor { get; set; }
        public Ram Ram { get; set; }
        public Graphics GraphicsCard { get; set; }
        public HardDrive HardDrive { get; set; }
        public PowerAdapter PowerAdapter { get; set; }
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = (Motherboard.Price + GraphicsCard.Price + Processor.Price +
                           Ram.Price + HardDrive.Price + PowerAdapter.Price); }
        }

        static int PriceCalc(Motherboard motherboard, Processor processor, Ram ram,
            Graphics graphics, HardDrive hardDrive, PowerAdapter power)
        {
            return (motherboard.Price + graphics.Price + processor.Price +
                    ram.Price + hardDrive.Price + power.Price);
        }
    }
}
