using System.Collections.Generic;
using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public class Iterator : IIterator
    {
        private ICollection aggregate;

        private List<Computer> collection = new List<Computer>();
        private int pointer = 0;

        public Iterator(ICollection aggregate)
        {
            this.aggregate = aggregate;
        }

        public int getAmount()
        {
            return collection.Count;
        }

        Computer IIterator.First()
        {
            pointer = 0;
            return collection[pointer];
        }

        Computer IIterator.Curr()
        {
            return collection[pointer];
        }

        Computer IIterator.Next()
        {
            return collection[pointer++];
        }

        void IIterator.AddComp(Computer comp)
        {
            collection.Add(comp);
        }

        public int Find(Computer comp)
        {
            return collection.IndexOf(comp);
        }

        public void Remove(Computer comp)
        {
            collection.Remove(comp);
        }

        bool IIterator.isJobDone()
        {
            if (pointer == collection.Count - 1)
                return true;
            else
                return false;
        }
    }
}