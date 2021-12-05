using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyStackArray<T> : IMyStack<T>
    {
        private const int initialCapacity = 8;
        private T[] storage = new T[initialCapacity];

        public int Count { get; private set; } = 0;

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Unable to peek empty Stack");
            return storage[Count-1];
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("Unable to pop empty Stack");
            return storage[--Count];
        }

        public void Push(T item)
        {
            if (Count + 1 >= storage.Length)
            {
                var newStorage = new T[storage.Length*2];
                Array.Copy(storage, newStorage, storage.Length);
                storage = newStorage;
            }
            storage[Count++] = item;
        }
    }
}
