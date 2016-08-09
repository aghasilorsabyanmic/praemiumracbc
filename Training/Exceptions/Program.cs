using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    throw new Exception();
                }
                finally
                {
                    Console.WriteLine("Finally");
                }
            }
            catch
            {
                Console.WriteLine("Catch");
            }
            
            
            //TryCatchFinallyExample();

        }

        private static int Length(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value.Length;
        }

        private static int? LengthAlt(string value)
        {
            return value?.Length;
        }

        private static void TryCatchFinallyExample()
        {
            try
            {
                var x = 1 / int.Parse(Console.ReadLine());
                DoWork();
            }
            catch (IOException ex)
            {

            }
            catch (OutOfMemoryException ex)
            {

            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (ArgumentNullException ex)
            {

            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (OverflowException ex)
            {

            }
            catch (DivideByZeroException ex)
            {

            }
            catch (StackOverflowException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private static NotImplementedException DoWork()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {

                throw;
            }
            
            //return new NotImplementedException();
        }
    }
}
