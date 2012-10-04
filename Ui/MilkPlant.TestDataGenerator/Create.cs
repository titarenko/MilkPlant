using System;
using System.ComponentModel;
using MilkPlant.Interfaces.Models;
using MilkPlant.Interfaces.Models.Base;
using MilkPlant.RestClient;
using MilkPlant.Shared;
using System.Linq;

namespace MilkPlant.TestDataGenerator
{
    [ThornExport]
    public class Create
    {
        private readonly IStorage storage;
        private readonly IFactory factory;
        private readonly IProgressReporter progressReporter;

        public Create() : this(new Storage(new AppConfiguration()), new Factory(), new ConsoleProgressReporter())
        {
        }

        public Create(IStorage storage, IFactory factory, IProgressReporter progressReporter)
        {
            this.storage = storage;
            this.factory = factory;
            this.progressReporter = progressReporter;
        }

        [Description("Creates specified number of products with random names.")]
        public void Products(Options options)
        {
            Func<string> randomName = () => string.Format(
                "{0} {1}", factory.Adjective.GetRandom().ToTileCase(), factory.Noun.GetRandom().ToTileCase());
            Collection<Product>(options, randomName);
        }

        [Description("Creates specified number of distributors with random names.")]
        public void Distributors(Options options)
        {
            Func<string> randomName = () => string.Format(
                "{0} {1}", factory.Name.GetRandom(), factory.Surname.GetRandom());
            Collection<Distributor>(options, randomName);
        }

        [Description("Creates specified number of sold item records with random distributors and products.")]
        public void SoldItems(Options options)
        {
            progressReporter.Start("creation of sold items");

            var products = GetRandomItemPicker<Product>();
            var distributors = GetRandomItemPicker<Distributor>();
            var collection = storage.Collection<SoldItem>();
            var index = options.Count;
            while (index-- > 0)
            {
                collection.Save(new SoldItem
                {
                    Date = Clock.Now, 
                    DistributorId = distributors.Pick(),
                    ProductId = products.Pick(),
                    Quantity = GetRandomQuantity()
                });
                progressReporter.Porgress(options.Count - index - 1, options.Count);
            }

            progressReporter.Finish();
        }

        private decimal GetRandomQuantity()
        {
            return GetRandom.Int(10, 50);
        }

        private RandomItemPicker<int> GetRandomItemPicker<T>() where T : Identifiable
        {
            return new RandomItemPicker<int>(storage.Collection<T>().GetAll().Select(x => x.Id).ToList(), new RandomGenerator());
        }

        private void Collection<T>(Options options, Func<string> nameGenerator) where T : Named, new()
        {
            progressReporter.Start(string.Format("creation of {0}s", typeof(T).Name.ToLower()));

            var collection = storage.Collection<T>();
            var index = options.Count;
            while (index-- > 0)
            {
                collection.Save(new T {Name = nameGenerator()});
                progressReporter.Porgress(options.Count - index - 1, options.Count);
            }

            progressReporter.Finish();
        }
    }
}