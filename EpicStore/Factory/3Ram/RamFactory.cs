using System;
using System.Collections.Generic;
using System.Text;
using EpicStore.Factory._3Ram.Stuff;

namespace EpicStore.Factory._3Ram
{
    class RamFactory : IRamFactory
    {
        private static readonly Lazy<RamFactory> _ramInstance =
            new Lazy<RamFactory>(() => Activator
                    .CreateInstance(typeof(RamFactory), true)
                as RamFactory);
        private RamFactory() { }

        public static RamFactory Instance
        {
            get { return _ramInstance.Value; }
        }

        public Ram TakeRam(int choice)
        {
            switch (choice)
            {
                case 1: return new Ram1();
                case 2: return new Ram2();
                case 3: return new Ram3();
                default: return null;
            }
        }
    }
}
