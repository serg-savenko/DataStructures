using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTests
{
    public class MyStackMyLinkedListTest : MyStackTest
    {
        protected override IMyStack<T> CreateMyStack<T>()
        {
            return new MyStackMyLinkedList<T>();
        }
    }
}
