using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var sh = new Shuffle<uint>(8);
        }

        static T[] Slice<T>(T[] values, int start, int count)
        {
            //TODO: Implement Algorithm
            throw new NotImplementedException();
        }

        //TODO Write Swap generic function

        
    }

    class Shuffle<T>
    {
        private T[] values;

        public Shuffle(int capacity)
        {
            values = new T[capacity];
        }

        public void Add(T value)
        {

        }
        
        public void Randomize()
        {

        } 
    }

    class MyGenericClass<T1, T2> where T1 : struct where T2 : class
    {
        public void F1(T1 value) { }

        public void F2(T1 value1, T2 value2) { }

        public void F3<T3>(T1 value1, T2 value2, T3 value3) where T3 : T2 { }
    }
}
