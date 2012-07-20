using System;
using System.ComponentModel;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;
using MilkPlant.Interfaces.Models;
using MilkPlant.Interfaces.Models.Base;
using MilkPlant.RestClient;
using MilkPlant.Shared;
using TestDataFactory;
using Thorn;
using System.Linq;

namespace MilkPlant.TestDataGenerator
{
    [ThornExport]
    public class Create
    {
        private readonly IStorage storage;
        private readonly IFactory factory;

        public Create() : this(new Storage(new AppConfiguration()), new Factory())
        {
        }

        public Create(IStorage storage, IFactory factory)
        {
            this.storage = storage;
            this.factory = factory;
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
            var products = GetRandomItemPicker<Product>();
            var distributors = GetRandomItemPicker<Distributor>();
            var collection = storage.Collection<SoldItem>();
            while (options.Count-- > 0)
            {
                collection.Save(new SoldItem
                {
                    Date = Clock.Now, 
                    DistributorId = distributors.Pick(),
                    ProductId = products.Pick(),
                    Quantity = GetRandomQuantity()
                });
            }
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
            var collection = storage.Collection<T>();
            while (options.Count-- > 0)
            {
                collection.Save(new T {Name = nameGenerator()});
            }
        }
    }
}