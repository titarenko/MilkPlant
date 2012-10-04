using System;
using System.Reflection;
using Thorn;

namespace MilkPlant.TestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Runner.Run(args);
            }
            catch (TargetInvocationException exception)
            {
                Console.WriteLine(exception.InnerException.Message);
            }
        }
    }
}