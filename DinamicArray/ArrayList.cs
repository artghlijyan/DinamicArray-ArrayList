using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
    class ArrayList<T> : IEnumerable<T>
    {
        T[] _items;

        public int Count { get; internal set; }
        public int Capacity => _items.Length;

        public T this[int index]
        {
            get
            {
                if (index > Count - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _items[index];
            }
            set
            {
                if (index > Count - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _items[index] = value;
            }
        }
        public ArrayList() : this(0)
        {

        }

        public ArrayList(int Capacity)
        {
            if (Capacity < 0)
            {
                throw new ArgumentException();
            }

            _items = new T[Capacity];
        }

        public ArrayList(ICollection<T> list)
        {
            int index = 0;
            _items = new T[list.Count];

            foreach (var element in list)
            {
                Count++;
                _items[index++] = element;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }


        public void Add(T item)
        {
            if (_items.Length == Count)
            {
                GrowArray();
            }

            _items[Count++] = item;
        }

        public void Insert(int index, T item)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (_items.Length == Count)
            {
                GrowArray();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index < Count - 1)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            }

            Count--;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        private void GrowArray()
        {
            int newLenght = _items.Length == 0 ? 4 : _items.Length << 1;
            T[] newArray = new T[newLenght];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
