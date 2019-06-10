using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public interface IIterator
    {
        Computer First();
        Computer Curr();
        Computer Next();
        void AddComp(Computer comp);
        int Find(Computer comp);
        void Remove(Computer comp);
        int getAmount();
        bool isJobDone();

    }
}