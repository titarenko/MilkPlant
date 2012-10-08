using System;

namespace MilkPlant.EntityBackend
{
    public class OutOfWaybillsException : ApplicationException
    {
        public OutOfWaybillsException() :
            base("No more waybills are available for today.")
        {
        }
    }
}