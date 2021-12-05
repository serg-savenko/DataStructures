
using System.Collections;

namespace DataStructures
{

    public class MyLinkedList<T> : IEnumerable<T>
    {
        public MyLinkedListNode<T>? First { get; private set; }
        public MyLinkedListNode<T>? Last { get; private set; }
        public int Count { get; private set; }

        private void Add(T value, MyLinkedListNode<T>? left, MyLinkedListNode<T>? right)
        {
            var newNode = new MyLinkedListNode<T>(value, left, right);
            if (left != null) { left.Next = newNode; }
            else { First = newNode; }
            if (right != null) { right.Previous = newNode; }
            else { Last = newNode; }
            Count++;
        }
        
        public void AddFirst(T value)
        {
            Add(value, null, First);
        }

        public void AddLast(T value)
        {
            Add(value, Last, null);
        }

        private void Remove(MyLinkedListNode<T> node)
        {
            if (node == null) throw new InvalidOperationException("Unable to Remove null node");

            // link previous one with next one
            if (node.Previous != null)
            {
                node.Previous.Next = node.Next;
            }

            // node was the first node
            if (node.Previous == null)
            {
                First = node.Next;
            }

            // node was the last node
            if (node.Next == null)
            {
                Last = node.Previous;
            }

            node.Previous = null;
            node.Next = null;
            Count--;

        }

        public void RemoveFirst()
        {
            if (First == null) throw new InvalidOperationException("Unable to RemoveFirst from empty list");

            Remove(First);
        }
        public void RemoveLast()
        {
            if (Last == null) throw new InvalidOperationException("Unable to RemoveFirst from empty list");

            Remove(Last);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyLinkedListNode<T>
    {
        internal MyLinkedListNode(T v, MyLinkedListNode<T>? previous = null, MyLinkedListNode<T>? next = null)
        {
            Value = v;
            Previous = previous;
            Next = next;
        }
        public T Value { get; internal set; }
        public MyLinkedListNode<T>? Previous { get; internal set; }
        public MyLinkedListNode<T>? Next { get; internal set; }
    }

}
