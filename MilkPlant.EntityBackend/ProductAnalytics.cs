using System.Collections.Generic;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;
using MilkPlant.Interfaces.Projections;
using System.Linq;

namespace MilkPlant.EntityBackend
{
    public class ProductAnalytics : IProductAnalytics
    {
        private readonly DataContext context = new DataContext();

        public IEnumerable<BestSeller> GetBestSellers(int count)
        {
            return context.Set<SoldItems>()
                .GroupBy(x => x.Product.Id) // group products
                .OrderByDescending(x => x.Sum(items => items.Quantity)) // order by sales volume
                .Select(grouping => new BestSeller // select best sellers
                {
                    Distributor = grouping // distributor
                        .GroupBy(x => x.Distributor.Id) // among others
                        .OrderByDescending(x => x.Sum(z => z.Quantity)) // is one with max sales volume
                        .Select(x => x.FirstOrDefault().Distributor.Name) // we need only name
                        .FirstOrDefault(), // and only top distributor
                    Name = grouping.FirstOrDefault().Product.Name, // we need only product name
                    SalesVolume = grouping.Sum(x => x.Quantity) // sales volume
                })
                .Take(count) // we interested in obtaining only first <count> best sellers
                .ToList(); // do query and return results
        }
    }
}