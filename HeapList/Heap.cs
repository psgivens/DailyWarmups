using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapList
{
    public class Heap
    {
        private readonly List<int> _list = new List<int>();

        public IEnumerable<int> Values { get { return _list; } }

        public Heap(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                Insert(value);
            }
        }

        private void Insert(int value)
        {
            _list.Add(value);
            int count = _list.Count;
            if (count == 1) return;
            int lastIndex = count - 1;
            int index = SwapWithParent(lastIndex);
            while (index != lastIndex && index > 0)
            {
                lastIndex = index;
                index = SwapWithParent(lastIndex);
            }

        }

        private int SwapWithParent(int index)
        {
            int parentIndex = GetParentIndex(index);
            int parent = _list[parentIndex];
            int current = _list[index];

            if (current > parent) return index;

            _list[parentIndex] = current;
            _list[index] = parent;
            return parentIndex;
        }

        private int SwapWithRightChild(int index)
        {
            int leftIndex = GetLeftIndex(index);
            int rightIndex = GetRightIndex(index);
            int left = _list[leftIndex];
            int right = _list[rightIndex];
            int current = _list[index];

            if (current < right) return index;

            _list[rightIndex] = current;
            _list[index] = right;
            return rightIndex;
        }

        private int GetParentIndex(int p)
        {
            return (p - 1) >> 1;
        }

        private int GetLeftIndex(int index)
        {
            return (index << 1) + 1;
        }

        private int GetRightIndex(int index)
        {
            return (index << 1) + 2;
        }
    }
}
