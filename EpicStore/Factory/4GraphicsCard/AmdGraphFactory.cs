using System;
using EpicStore.Factory._4GraphicsCard.AMDStuff;
using EpicStore.Factory._4GraphicsCard.nVidiaStuff;

namespace EpicStore.Factory._4GraphicsCard
{
    public class AmdGraphFactory : IGraphicsFactory
    {
        private static readonly Lazy<AmdGraphFactory> _graphInstance =
            new Lazy<AmdGraphFactory>(() => Activator
                    .CreateInstance(typeof(AmdGraphFactory), true)
                as AmdGraphFactory);
        private AmdGraphFactory() { }

        public static AmdGraphFactory Instance
        {
            get { return _graphInstance.Value; }
        }

        public Graphics TakeGraphicsCard(int choice)
        {
            switch (choice)
            {
                case 1: return new AmdGraph1();
                case 2: return new AmdGraph2();
                case 3: return new AmdGraph3();
                default: return null;
            }
        }
    }
}