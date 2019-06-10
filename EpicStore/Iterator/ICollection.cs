using System.Collections.Generic;
using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public interface ICollection
    {
        IIterator CreateIterator();
        List<Computer> GetAllComputers();
        Computer GetOne(Computer comp);
        void AddComp(Computer comp);
        void RemComp(Computer comp);
    }
}