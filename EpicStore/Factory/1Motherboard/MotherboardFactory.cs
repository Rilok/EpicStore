using System;
using System.Collections.Generic;
using System.Text;
using EpicStore.Factory._1Motherboard.Stuff;

namespace EpicStore.Factory._1Motherboard
{
    class MotherboardFactory : IMotherboardFactory
    {
        private static readonly Lazy<MotherboardFactory> _mothInstance = 
            new Lazy<MotherboardFactory>(() => Activator
                .CreateInstance(typeof(MotherboardFactory), true)
            as MotherboardFactory);
        private MotherboardFactory() { }

        public static MotherboardFactory Instance
        {
            get { return _mothInstance.Value; }
        }

        public Motherboard TakeMotherboard(int choice)
        {
            switch (choice)
            {
                case 1: return new Mother1();
                case 2: return new Mother2();
                case 3: return new Mother3();
                default: return null;
            }
        }


    }
}
