using System.Collections.Generic;
using DevExpress.Xpo;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Projections;
using System.Linq;
using MilkPlant.XpoBackend.Models;

namespace MilkPlant.XpoBackend
{
    public class ProductAnalytics : IProductAnalytics
    {
        private readonly DataContext context = new DataContext();

        public IEnumerable<BestSeller> GetBestSellers(int count)
        {
            using (var session = context.GetSession())
            {
                var bestSellers = new XPQuery<SoldItem>(session)
                    .GroupBy(x => x.Product.Name)
                    .Select(x => new BestSeller
                    {
                        Name = x.Key,
                        SalesVolume = x.Sum(z => z.Quantity)
                    })
                    .OrderByDescending(x => x.SalesVolume)
                    .Take(count)
                    .ToList();

                foreach (var bestSeller in bestSellers)
                {
                    bestSeller.Distributor = new XPQuery<SoldItem>(session)
                        .Where(x => x.Product.Name == bestSeller.Name)
                        .GroupBy(x => x.Distributor.Name)
                        .Select(x => new
                        {
                            Name = x.Key,
                            SalesVolume = x.Sum(z => z.Quantity)
                        })
                        .OrderByDescending(x => x.SalesVolume)
                        .First()
                        .Name;
                }

                return bestSellers;
            }
        }
    }
}