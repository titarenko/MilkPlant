using RestSharp;

namespace MilkPlant.RestClient
{
    public class Collection<T>
    {
        private readonly IRestClient client;
        private readonly string resource;

        public Collection(IRestClient client)
        {
            this.client = client;
            resource = typeof (T).Name.ToLower();
        }

        public void Save(T instance)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddObject(instance);
            client.Execute(request);
        }
    }
}