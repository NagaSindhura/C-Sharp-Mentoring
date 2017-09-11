using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsAndGenerics
{
    public class CustomCollection<T> : ICollection<T>, IEnumerator<T>
    {
        private int _count;
        private int _position;

        private int _capacity;

        private object[] _items;

        public CustomCollection()
        {
            _items = _items ?? new object[0];
        }

        //Count ->  readonly property
        public int Count => _count;

        public int Capacity => _capacity;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (_count >= Capacity || _items.Length == 0)
            {
                _capacity = (_capacity == 0 ? _capacity = 1 : _capacity) * 2;
                Array.Resize(ref _items, _capacity);
            }

            _items[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _count = 0;
            _items = null;
        }

        public bool Contains(T item)
        {
            var inList = false;
            for (var i = 0; i < _count; i++)
            {
                if (!_items[i].Equals(item))
                {
                    continue;
                }

                inList = true;
                break;
            }

            return inList;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var j = arrayIndex;
            for (var i = 0; i < _count; i++)
            {
                array.SetValue(_items[i], j);
                j++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Cast<T>().TakeWhile(item => item != null).GetEnumerator();
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        private int IndexOf(object value)
        {
            var itemIndex = -1;
            for (var i = 0; i < _count; i++)
            {
                if (_items[i] != value)
                {
                    continue;
                }

                itemIndex = i;
                break;
            }

            return itemIndex;
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= _count))
            {
                return;
            }

            if (index == _count - 1)
            {
                _items[index] = null;
            }
            else
            {
                for (var i = index; i < _count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }

                if (index == 0)
                {
                    _items[_count - 1] = null;
                }
            }

            _count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T Current => (T)_items[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _items = null;
            _position--;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}