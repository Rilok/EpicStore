using System.Collections.Generic;
using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public class CompCollection : ICollection
    {
        private IIterator iterator;

        public CompCollection()
        {
            (this as ICollection).CreateIterator();
        }

        IIterator ICollection.CreateIterator()
        {
            if (iterator == null)
                iterator = new Iterator(this);
            return iterator;
        }

        List<Computer> ICollection.GetAllComputers()
        {
            List<Computer> compList = new List<Computer>();
            if (iterator.getAmount() != 0)
            {
                compList.Add(iterator.First());
                while (!iterator.isJobDone())
                {
                    compList.Add(iterator.Next());
                }
            }

            return compList;
        }

        void ICollection.AddComp(Computer comp)
        {
            iterator.AddComp(comp);
        }

        Computer ICollection.GetOne(Computer comp)
        {
            var holder = iterator.First();
            while (!iterator.isJobDone())
            {
                if (holder.Equals(comp))
                    return holder;
                else
                    holder = iterator.Next();
            }
            return holder;
        }

        public void RemComp(Computer comp)
        {
            int index = iterator.Find(comp);
            if (index != -1)
                iterator.Remove(comp);
        }
    }
}