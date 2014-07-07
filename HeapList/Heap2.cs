using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeapList
{
    public class Heap2
    {
        private List<int> _list = new List<int>();

        public Heap2(int[] array)
        {
            foreach (var value in array)
            {
                Insert(value);
            }
        }

        private void Insert(int value)
        {
            _list.Add(value);
            var count = _list.Count;
            if (count == 1) return;

            int lastIndex = count - 1;
            int i = SwapWithParent(lastIndex);
            while (i != lastIndex && i != 0)
            {
                lastIndex = i;
                i = SwapWithParent(i);
            }
        }

        private int SwapWithParent(int index)
        {
            if (index == 0) return 0;
            int parentIndex = GetParentIndex(index);
            int parent = _list[parentIndex];
            int current = _list[index];
            if (current > parent) return index;

            _list[parentIndex] = current;
            _list[index] = parent;
            return parentIndex;
        }

        private int GetParentIndex(int index) { return (index - 1) >> 1; }
        private int GetLeftIndex(int index) { return (index << 1) + 1; }
        private int GetRightIndex(int index) { return (index >> 1) + 2; }

        public IEnumerable<int> Values { get { return _list; } }

        internal int Pop()
        {
            int value = _list[0];
            int lastIndex = _list.Count - 1;
            int last = _list[lastIndex];
            _list[0] = last;
            _list.RemoveAt(lastIndex);

            int finalIndex = _list.Count - 1;

            lastIndex = 0;
            int index = SwapWithChild(0);
            while(index != lastIndex && lastIndex < finalIndex)
            {
                lastIndex = index;
                index = SwapWithChild(index);
            }

            return value;
        }

        private int SwapWithChild(int index)
        {
            throw new NotImplementedException();
        }
    }
}
