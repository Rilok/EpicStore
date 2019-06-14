using System;
using EpicStore.Factory._5HardDrive.HddStuff;
using EpicStore.Factory._5HardDrive.SsdStuff;

namespace EpicStore.Factory._5HardDrive
{
    public class SSDFactory : IHardDriveFactory
    {
        private static readonly Lazy<SSDFactory> _hardDriveInstance =
            new Lazy<SSDFactory>(() => Activator
                    .CreateInstance(typeof(SSDFactory), true)
                as SSDFactory);
        private SSDFactory() { }

        public static SSDFactory Instance
        {
            get { return _hardDriveInstance.Value; }
        }

        public HardDrive TakeHardDrive(int choice)
        {
            switch (choice)
            {
                case 1: return new Ssd1();
                case 2: return new Ssd2();
                default: return null;
            }
        }
    }
}