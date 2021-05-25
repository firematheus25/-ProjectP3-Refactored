using miscellaneous.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectP3.Services
{
    public class Services<T> : MyClient
    {

        public async Task<List<T>> Get(string Api)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api);

                var result = await client.GetAsync(url);

                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<T>>(json).ToList();

                    return model;
                }
                return null;
            }
        }


        public async Task<T> GetById(string Api, string Id)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api, Id);

                var result = await client.GetAsync(url);
                var json = await result.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<T>(json);
                return model;
            }
        }


        public async Task<List<T>> GetByIds(string Api, string Id)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api, Id);

                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<List<T>>(json).ToList();

                    return model;
                }

                return null;
            }
        }


        public async Task<HttpResponseMessage> Post(string Api, T Objeto)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api);

                var Json = JsonConvert.SerializeObject(Objeto, Formatting.None);

                var Content = new StringContent(Json, Encoding.UTF8, "application/Json");

                return await client.PostAsync(url, Content);
            }
        }

        public async Task<HttpResponseMessage> Put(string Api, T Objeto)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api);

                var Json = JsonConvert.SerializeObject(Objeto, Formatting.None);

                var Content = new StringContent(Json, Encoding.UTF8, "application/Json");

                return await client.PutAsync(url, Content);
            }
        }

        public async Task<HttpResponseMessage> Delete(string Api, string Id)
        {
            using (var client = new HttpClient())
            {
                var url = new MyClient().BuilderUri(Api, Id);

                return await client.DeleteAsync(url);
            }
        }

    }
}
