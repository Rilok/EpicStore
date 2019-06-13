using System;
using EpicStore.Factory._4GraphicsCard.AMDStuff;
using EpicStore.Factory._4GraphicsCard.nVidiaStuff;

namespace EpicStore.Factory._4GraphicsCard
{
    public class GraphicsFactory : IGraphicsFactory
    {
        private static readonly Lazy<GraphicsFactory> _graphInstance =
            new Lazy<GraphicsFactory>(() => Activator
                    .CreateInstance(typeof(GraphicsFactory), true)
                as GraphicsFactory);
        private GraphicsFactory() { }

        public static GraphicsFactory Instance
        {
            get { return _graphInstance.Value; }
        }

        public Graphics TakeGraphicsCard(string brand, int choice)
        {
            switch (brand)
            {
                case "AMD":
                {
                    switch (choice)
                    {
                        case 1: return new AmdGraph1();
                        case 2: return new AmdGraph2();
                        default: return null;
                    }
                }

                case "Intel":
                {
                    switch (choice)
                    {
                        case 1: return new nVidiaGraph1();
                        case 2: return new nVidiaGraph2();
                        case 3: return new nVidiaGraph3();
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