
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void MyDelegate(int x); 

    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new MyDelegate(F);
            MyDelegate d2 = F;
            MyDelegate d3 = delegate (int value) { };
            MyDelegate d4 = (a) => { };
            MyDelegate d5 = (int a) => { };
            MyDelegate d6 = a => Console.WriteLine(a);

            MyDelegate d7;

            d7 = F;
            DelegateF(d7);
            d7 -= F;
            DelegateF(d7);
            d7 -= F;
            DelegateF(d7);
            d7 += d3;

            var array = new int[] { 1, 2, 3 };

            //ArrayF(array, (x) => { return x[0]; });
            ArrayF(array, (x) => x[0]);
            ArrayF(array, (x) => {
                var sum = 0;

                foreach (var item in x)
                {
                    sum += item;
                }

                return sum;
            });
        }

        static void DelegateF(MyDelegate d)
        {
            Console.WriteLine(d == null ? "Null" : "Not Null");

            //if (d != null)
            //{
            //    d(2);
            //}

            d?.Invoke(2);
        }

        static void F(int n)
        {
            
        }

        static int ArrayF(int[] array, Func<int[], int> callback)
        {
            if(array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            var result = callback(array);
            return result;
        }
    }
}
