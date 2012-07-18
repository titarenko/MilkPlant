using System.Collections.Generic;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.Interfaces
{
    public interface IProductAnalytics
    {
        IEnumerable<BestSeller> GetBestSellers(int count);
    }
}