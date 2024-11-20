using PathFindingEcs.Helpers;
using Unity.Collections;

namespace PathFindingEcs.Components
{
    public class Heap
    {
        NativeList<PathNodeData> _items;
        int _currentItemCount;

        public Heap(Allocator allocator)
        {
            _currentItemCount = 0;
            _items = new NativeList<PathNodeData>(allocator);
        }

        public void Enqueue(PathNodeData item)
        {
            item.HeapIndex = _currentItemCount;

            if (_currentItemCount >= _items.Length)
            {
                _items.Add(item);
            }
            else
            {
                _items[_currentItemCount] = item;
            }

            SortUp(item);
            _currentItemCount++;
        }

        public PathNodeData Dequeue()
        {
            PathNodeData firstItem = _items[0];
            _currentItemCount--;
            _items[0] = _items[_currentItemCount];
            var item = _items[0];
            item.HeapIndex = 0;
            _items[0] = item;
            if (_items.Length != 0)
            {
                _items.RemoveAt(_currentItemCount);

                if (_items.Length != 0) SortDown(_items[0]);
            }

            return firstItem;
        }

        public int Count => _items.Length;

        public bool Contains(PathNodeData item)
        {
            if (item.HeapIndex < 0 || item.HeapIndex >= _items.Length) return false;

            foreach (var listItem in _items)
            {
                if (listItem.nodeGridData.Position.CompareFloat(item.nodeGridData.Position))
                {
                    return true;
                }
            }

            return false;
        }

        void SortDown(PathNodeData item)
        {
            while (true)
            {
                int childIndexLeft = item.HeapIndex * 2 + 1;
                int childIndexRight = item.HeapIndex * 2 + 2;
                int swapIndex = 0;

                if (childIndexLeft < _currentItemCount)
                {
                    swapIndex = childIndexLeft;

                    if (childIndexRight < _currentItemCount)
                    {
                        if (_items[childIndexLeft].CompareTo(_items[childIndexRight]) < 0)
                        {
                            swapIndex = childIndexRight;
                        }
                    }

                    if (item.CompareTo(_items[swapIndex]) < 0)
                    {
                        var itemB = _items[swapIndex];
                        Swap(ref item, ref itemB);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        void SortUp(PathNodeData item)
        {
            int parentIndex = (item.HeapIndex - 1) / 2;

            while (true)
            {
                PathNodeData parentItem = _items[parentIndex];
                if (item.CompareTo(parentItem) > 0)
                {
                    Swap(ref item, ref parentItem);
                }
                else
                {
                    break;
                }

                parentIndex = (item.HeapIndex - 1) / 2;
            }
        }

        void Swap(ref PathNodeData itemA, ref PathNodeData itemB)
        {
            PathNodeData tempA = _items[itemA.HeapIndex];
            PathNodeData tempB = _items[itemB.HeapIndex];

            _items[itemA.HeapIndex] = tempB;
            _items[itemB.HeapIndex] = tempA;

            (itemA.HeapIndex, itemB.HeapIndex) = (itemB.HeapIndex, itemA.HeapIndex);

            _items[itemA.HeapIndex] = itemA;
            _items[itemB.HeapIndex] = itemB;
        }

        public void Dispose()
        {
            _items.Dispose();
        }

        public void Clear()
        {
            if (!_items.IsCreated) return;

            _items.Clear();
        }
    }
}