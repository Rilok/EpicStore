using System;
using EpicStore.Factory._6PowerAdapter.Stuff;

namespace EpicStore.Factory._6PowerAdapter
{
    public class PowerFactory : IPowerFactory
    {
        private static readonly Lazy<PowerFactory> _powerInstance =
            new Lazy<PowerFactory>(() => Activator.
                CreateInstance(typeof(PowerFactory), true)
            as PowerFactory);

        private PowerFactory() { }

        public static PowerFactory Instance
        {
            get { return _powerInstance.Value; }
        }

        public PowerAdapter TakePowerAdapter(int choice)
        {
            switch (choice)
            {
                case 1: return new Power1();
                case 2: return new Power2();
                default: return new Power3();
            }
        }
    }
}