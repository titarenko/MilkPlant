using System;

namespace MilkPlant.EntityBackend
{
    public class OutOfStockException : ApplicationException
    {
        public OutOfStockException()
            : base("Warehouse contains no items of requested product.")
        {
        }
    }
}