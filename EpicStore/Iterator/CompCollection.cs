using System.Collections;
using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public class CompCollection : ICollection
    {
        private ArrayList _computers = new ArrayList();

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int NumberOfComputers
        {
            get { return _computers.Count; }
        }

        public object this[int index]
        {
            get { return _computers[index]; }
            set { _computers.Add(value); }
        }

        public void Add(object computer)
        {
            _computers.Add(computer);
        }
    }
}