namespace EpicStore.Factory._4GraphicsCard
{
    public interface IGraphicsFactory
    {
        Graphics TakeGraphicsCard(string brand, int choice);
    }
}