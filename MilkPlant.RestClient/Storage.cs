using MilkPlant.Shared;

namespace MilkPlant.RestClient
{
    public class Storage
    {
        private readonly RestSharp.RestClient client;

        public Storage(IConfiguration configuration)
        {
            client = new RestSharp.RestClient(configuration.Get("BaseUrl"));
        }

        public Collection<T> Collection<T>()
        {
            return new Collection<T>(client);
        }
    }
}