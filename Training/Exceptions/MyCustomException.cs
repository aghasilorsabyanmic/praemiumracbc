using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class MyCustomException : Exception
    {
        public MyCustomException()
            : base("My Custom Exception Occured")
        {
            X = 5;
        }

        public MyCustomException(string message)
            : base(message)
        {
            X = 5;
        }

        public MyCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
            X = 5;
        }

        public MyCustomException(int y) : this()
        {
            Y = y;
        }

        public MyCustomException(int y, string message)
            : this(message)
        {
            Y = y;
        }

        public MyCustomException(int y, string message, Exception innerException)
            : this(message, innerException)
        {
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
