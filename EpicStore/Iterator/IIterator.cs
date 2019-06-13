using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public interface IIterator
    {
        Computer First();
        Computer Next();
        Computer GetCurrent { get; }
        bool IsDone { get; }
    }
}