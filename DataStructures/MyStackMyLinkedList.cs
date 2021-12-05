using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyStackMyLinkedList<T> : IMyStack<T>
    {
        private MyLinkedList<T> storage = new();

        public int Count => storage.Count;

        public T Peek()
        {
            if (storage.First == null) throw new InvalidOperationException("Unable to peek empty Stack");
            return storage.First.Value;
        }

        public T Pop()
        {
            if (storage.First == null) throw new InvalidOperationException("Unable to pop empty Stack");
            T item = storage.First.Value;
            storage.RemoveFirst();
            return item;
        }

        public void Push(T item)
        {
            storage.AddFirst(item);
        }
    }
}
