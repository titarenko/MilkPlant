using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace MilkPlant.RestClient
{
    public class Collection<T> : ICollection<T>
    {
        private readonly IRestClient client;
        private readonly string resource;

        public Collection(IRestClient client)
        {
            this.client = client;
            resource = typeof (T).Name.ToLower() + "s";
        }

        public void Save(T instance)
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddObject(instance);
            VerifyResponse(client.Execute(request));
        }

        public IEnumerable<T> GetAll()
        {
            var request = new RestRequest(resource, Method.GET);
            var response = client.Execute<List<T>>(request);
            VerifyResponse(response);
            return response.Data;
        }

        private void VerifyResponse(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ApplicationException(string.Format(
                    "REST API call failed (Verb: {2}, URI: {0}, Code: {1}).", 
                    response.ResponseUri, response.StatusCode, response.Request.Method));
            }
        }
    }
}