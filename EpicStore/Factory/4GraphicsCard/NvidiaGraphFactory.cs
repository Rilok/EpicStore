using System;
using EpicStore.Factory._4GraphicsCard.nVidiaStuff;

namespace EpicStore.Factory._4GraphicsCard
{
    public class NvidiaGraphFactory : IGraphicsFactory
    {
        private static readonly Lazy<NvidiaGraphFactory> _graphInstance =
            new Lazy<NvidiaGraphFactory>(() => Activator
                    .CreateInstance(typeof(NvidiaGraphFactory), true)
                as NvidiaGraphFactory);
        private NvidiaGraphFactory() { }

        public static NvidiaGraphFactory Instance
        {
            get { return _graphInstance.Value; }
        }

        public Graphics TakeGraphicsCard(int choice)
        {
            switch (choice)
            {
                case 1: return new nVidiaGraph1();
                case 2: return new nVidiaGraph2();
                case 3: return new nVidiaGraph3();
                default: return null;
            }
        }
    }
}