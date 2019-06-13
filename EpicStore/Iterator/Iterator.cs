using EpicStore.Builder;

namespace EpicStore.Iterator
{
    public class Iterator : IIterator
    {
        private CompCollection _computerCollection;
        private int _curr = 0;
        private int _step = 1;

        public Iterator(CompCollection computerCollection)
        {
            this._computerCollection = computerCollection;
        }

        public Computer First()
        {
            _curr = 0;
            return _computerCollection[_curr] as Computer;
        }

        public Computer Next()
        {
            _curr += _step;
            if (!IsDone)
                return _computerCollection[_curr] as Computer;
            else
                return null;
        }

        public int Curr
        {
            get { return _curr; }
            set { _curr = value; }
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public Computer GetCurrent
        {
            get { return _computerCollection[_curr] as Computer;}
        }

        public bool IsDone
        {
            get { return _curr >= _computerCollection.NumberOfComputers; }
        }
    }
}