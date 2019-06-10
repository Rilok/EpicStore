using System;
using System.Collections.Generic;
using System.Text;
using EpicStore.Factory;
using EpicStore.Factory._1Motherboard;
using EpicStore.Factory._2Processor;
using EpicStore.Factory._3Ram;
using EpicStore.Factory._4GraphicsCard;
using EpicStore.Factory._5HardDrive;
using EpicStore.Factory._6PowerAdapter;


namespace EpicStore.Builder
{
    class LowEndBuilder : ComputerBuilder
    {
        private int m = 0; // Motherboard
        private int p = 0; // Processor
        private int r = 0; // Ram
        private int g = 0; // Graphics Card
        private int d = 0; // Storage (HDD or SSD)
        private int po = 0; // Power Adapter
        private string graphChoice = null;
        private string driveChoice = null;
        public LowEndBuilder(int m, int p, int r, int g, int d, int po,
            string graphChoice, string driveChoice)
        {
            this.m = m;
            this.p = p;
            this.r = r;
            this.g = g;
            this.d = d;
            this.po = po;
            this.graphChoice = graphChoice;
            this.driveChoice = driveChoice;
            _computerUnit = Build();
        }

        public override Computer Build()
        {
            return new Computer();
        }

        public override ComputerBuilder InstallMotherboard()
        {
            _computerUnit.Motherboard = MotherboardFactory.Instance.TakeMotherboard(m);
            return this;
        }

        public override ComputerBuilder InstallProcessor()
        {
            if (_computerUnit.Motherboard.Socket == "1151")
            {
                _computerUnit.Processor = ProcessorFactory.Instance.TakeProcessor("Intel", p);
            }
            else if (_computerUnit.Motherboard.Socket == "AM4")
            {
                _computerUnit.Processor = ProcessorFactory.Instance.TakeProcessor("AMD", p);
            }
            return this;
        }

        public override ComputerBuilder InstallRam()
        {
            _computerUnit.Ram = RamFactory.Instance.TakeRam(r);
            return this;
        }

        public override ComputerBuilder InstallGraphicsCard()
        {
            if (graphChoice == "AMD")
            {
                _computerUnit.GraphicsCard = GraphicsFactory.Instance.TakeGraphicsCard("AMD", g);
            }
            else if (graphChoice == "nVidia")
            {
                _computerUnit.GraphicsCard = GraphicsFactory.Instance.TakeGraphicsCard("nVidia", g);
            }
            return this;
        }

        public override ComputerBuilder InstallHardDrive()
        {
            if (driveChoice == "SSD")
            {
                _computerUnit.HardDrive = HardDriveFactory.Instance.TakeHardDrive("SSD", d);
            }
            else if (driveChoice == "HDD")
            {
                _computerUnit.HardDrive = HardDriveFactory.Instance.TakeHardDrive("HDD", d);
            }
            return this;
        }

        public override ComputerBuilder InstallPowerAdapter()
        {
            _computerUnit.PowerAdapter = PowerFactory.Instance.TakePowerAdapter(po);
            return this;
        }

        public override ComputerBuilder SetPrice()
        {
            _computerUnit.Price = (_computerUnit.Motherboard.Price + _computerUnit.Processor.Price +
                                   _computerUnit.Ram.Price + _computerUnit.GraphicsCard.Price +
                                   _computerUnit.HardDrive.Price + _computerUnit.PowerAdapter.Price);
            return this;
        }
    }
}
