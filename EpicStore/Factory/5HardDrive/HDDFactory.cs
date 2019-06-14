using System;
using EpicStore.Factory._5HardDrive.HddStuff;

namespace EpicStore.Factory._5HardDrive
{
    public class HDDFactory : IHardDriveFactory
    {
        private static readonly Lazy<HDDFactory> _hardDriveInstance =
            new Lazy<HDDFactory>(() => Activator
                    .CreateInstance(typeof(HDDFactory), true)
                as HDDFactory);
        private HDDFactory() { }

        public static HDDFactory Instance
        {
            get { return _hardDriveInstance.Value; }
        }

        public HardDrive TakeHardDrive(int choice)
        {
            switch (choice)
            {
                case 1: return new Hdd1();
                case 2: return new Hdd2();
                default: return null;
            }
        }
    }
}