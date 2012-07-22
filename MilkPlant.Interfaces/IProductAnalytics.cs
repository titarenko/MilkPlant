using System.Collections.Generic;
using MilkPlant.Interfaces.Projections;

namespace MilkPlant.Interfaces
{
    public interface IProductAnalytics
    {
        IEnumerable<BestSeller> GetBestSellers(int count);
    }
}