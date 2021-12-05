using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTests
{
    public class MyStackArrayTest : MyStackTest
    {
        protected override IMyStack<T> CreateMyStack<T>()
        {
            return new MyStackArray<T>();
        }
    }
}
