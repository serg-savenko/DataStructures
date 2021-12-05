using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using Xunit;

namespace DataStructuresTests
{
    abstract public class MyStackTest
    {
        abstract protected IMyStack<T> CreateMyStack<T>();
        
        [Fact]
        public void CountIsOneForStackWithOneElement()
        {
            var s = CreateMyStack<int>();
            s.Push(1);
            Assert.Equal(1, s.Count);
        }

        [Fact]
        public void PeekReturnsLastPushedValue()
        {
            var s = CreateMyStack<int>();
            s.Push(1);
            s.Push(1);
            s.Push(3);
            Assert.Equal(3, s.Peek());
        }

        [Fact]
        public void PushIncreasesCount()
        {
            var s = CreateMyStack<int>();
            s.Push(1);
            Assert.Equal(1, s.Count);
            s.Push(2);
            Assert.Equal(2, s.Count);
        }

        [Fact]
        public void PopReturnsLastPushedValue()
        {
            var s = CreateMyStack<int>();
            s.Push(1);
            s.Push(1);
            s.Push(3);
            Assert.Equal(3, s.Pop());
        }

        [Fact]
        public void PopDecreasesCount()
        {
            var s = CreateMyStack<int>();
            s.Push(1);
            s.Push(1);
            s.Push(3);
            s.Pop();
            Assert.Equal(2, s.Count);
            s.Pop();
            Assert.Equal(1, s.Count);
            s.Pop();
            Assert.Equal(0, s.Count);
        }

        [Fact]
        public void PopOnEmptyStackThrowsException()
        {
            var s = CreateMyStack<int>();
            Assert.Throws<InvalidOperationException>(() => s.Pop());
        }

        [Fact]
        public void PeekOnEmptyStackThrowsException()
        {
            var s = CreateMyStack<int>();
            Assert.Throws<InvalidOperationException>(() => s.Peek());
        }

        [Theory]
        [InlineData(1024)]
        [InlineData(1024*4)]
        public void StackCanHandleNElements(int n)
        {
            var s = CreateMyStack<int>();
            for (int i = 0; i < n; i++)
            {
                s.Push(i);
            }
            Assert.Equal(n, s.Count);
        }

    }
}
