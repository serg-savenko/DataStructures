using Xunit;
using DataStructures;
using System;

namespace DataStructuresTests
{
    public class MyLinkedListTest
    {

        [Fact]
        public void FirstIsNullForEmptyList()
        {
            var l = new MyLinkedList<int>();
            Assert.Null(l.First);
        }

        [Fact]
        public void LastIsNullForEmptyList()
        {
            var l = new MyLinkedList<int>();
            Assert.Null(l.Last);
        }

        [Fact]
        public void CountIsZeroForEmptyList()
        {
            var l = new MyLinkedList<int>();
            Assert.Equal(0, l.Count);
        }

        [Fact]
        public void CountReflectsNumberOfElements()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            Assert.Equal(2, l.Count);
        }

        [Fact]
        public void AddLastOnEmptyList()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            Assert.Equal(1, l.Last?.Value);
        }

        [Fact]
        public void AddFirstOnEmptyList()
        {
            var l = new MyLinkedList<int>();
            l.AddFirst(1);
            Assert.Equal(1, l.First?.Value);
        }

        [Fact]
        public void AddFirstOnEmptyListSetsLastProperty()
        {
            var l = new MyLinkedList<int>();
            l.AddFirst(1);
            Assert.Equal(1, l.Last?.Value);
        }

        [Fact]
        public void AddLastOnNonEmptyList()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            Assert.Equal(2, l.Last?.Value);
        }

        [Fact]
        public void AddFirstOnNonEmptyList()
        {
            var l = new MyLinkedList<int>();
            l.AddFirst(1);
            l.AddFirst(2);
            Assert.Equal(2, l.First?.Value);
        }

        [Fact]
        public void RemoveFirstOnEmptyListThrowsException()
        {
            var l = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(l.RemoveFirst);
        }

        [Fact]
        public void RemoveFirst()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            var count = l.Count;
            var el = l.First;
            l.RemoveFirst();

            Assert.True(l.Count == count - 1, "Count is one less than before RemoveFirst");
            Assert.True(l.First.Value == 2, "Second element became First");
            Assert.True(el.Previous is null, "Removed Node.Previous should be null");
            Assert.True(el.Next is null, "Removed Node.Next should be null");
        }

        [Fact]
        public void RemoveFirstOnListWithOneElement()
        {
            var l = new MyLinkedList<int>();
            l.AddFirst(1);
            var el = l.First;
            l.RemoveFirst();
            Assert.True(l.Count == 0, "Count should be zero");
            Assert.True(l.First is null, "First should be null");
            Assert.True(l.Last is null, "Last should be null");
        }

        [Fact]
        public void RemoveLast()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            var count = l.Count;
            var el = l.Last;
            l.RemoveLast();

            Assert.True(l.Count == count - 1, "Count is one less than before RemoveFirst");
            Assert.True(l.Last.Value == 2, "Next to last element became Last");
            Assert.True(el.Previous is null, "Removed Node.Previous should be null");
            Assert.True(el.Next is null, "Removed Node.Next should be null");
        }

        [Fact]
        public void RemoveLastOnListWithOneElement()
        {
            var l = new MyLinkedList<int>();
            l.AddFirst(1);
            var el = l.Last;
            l.RemoveLast();
            Assert.True(l.Count == 0, "Count should be zero");
            Assert.True(l.First is null, "First should be null");
            Assert.True(l.Last is null, "Last should be null");
        }

        [Fact]
        public void MyLinkedListIterator()
        {
            var l = new MyLinkedList<int>();
            l.AddLast(1);
            l.AddLast(1);
            l.AddLast(1);

            Assert.Equal("1,1,1", string.Join(",", l));
        }

    }
}