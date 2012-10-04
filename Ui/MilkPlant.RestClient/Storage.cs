using MilkPlant.Shared;

namespace MilkPlant.RestClient
{
    public class Storage : IStorage
    {
        private readonly RestSharp.RestClient client;

        public Storage(IConfiguration configuration)
        {
            client = new RestSharp.RestClient(configuration.GetValue("BaseUri"));
        }

        public ICollection<T> Collection<T>()
        {
            return new Collection<T>(client);
        }
    }
}