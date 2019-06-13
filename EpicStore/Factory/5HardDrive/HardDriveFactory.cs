﻿using System;
using EpicStore.Factory._5HardDrive.HddStuff;
using EpicStore.Factory._5HardDrive.SsdStuff;

namespace EpicStore.Factory._5HardDrive
{
    public class HardDriveFactory : IHardDriveFactory
    {
        private static readonly Lazy<HardDriveFactory> _hardDriveInstance =
            new Lazy<HardDriveFactory>(() => Activator
                    .CreateInstance(typeof(HardDriveFactory), true)
                as HardDriveFactory);
        private HardDriveFactory() { }

        public static HardDriveFactory Instance
        {
            get { return _hardDriveInstance.Value; }
        }

        public HardDrive TakeHardDrive(string type, int choice)
        {
            switch (type)
            {
                case "SSD":
                {
                    switch (choice)
                    {
                        case 1: return new Ssd1();
                        case 2: return new Ssd2();
                        default: return null;
                    }
                }

                case "HDD":
                {
                    switch (choice)
                    {
                        case 1: return new Hdd1();
                        case 2: return new Hdd2();
                        default: return null;
                    }
                }

                default:
                {
                    return null;
                }
            }
        }
    }
}