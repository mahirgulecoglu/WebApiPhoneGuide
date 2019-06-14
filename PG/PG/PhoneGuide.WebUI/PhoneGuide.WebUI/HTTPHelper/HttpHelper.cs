using PhoneGuide.WebUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneGuide.WebUI.HTTPHelper
{
    public class HttpHelper
    {
        public static T GetList<T>(string host, string resource, Method httpMethod)
            where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);

            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void PostRequest(string host, string resource, Method Httpmethod, object obj)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddJsonBody(obj);
            client.Execute(request);
        }

        public static T GetRequestByID<T>(string host, string resource, Method httpMethod, int id)
           where T : new()
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, httpMethod);
            request.AddParameter("id", id);
            var response2 = client.Execute<T>(request);
            return response2.Data;
        }

        public static void DeleteRequest(string host, string resource, Method Httpmethod, int id)
        {
            var client = new RestClient(host);
            var request = new RestRequest(resource, Httpmethod);
            request.AddParameter("id", id);
            client.Execute(request);
        }

    }
}