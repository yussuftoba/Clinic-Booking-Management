using ApiConsume;
using Dto;
using Models;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net.Http;

namespace YatApp.UI_PresentaionLayer.ApiConsume
{
    public class ApiCall : IApiCall
    {
        string baseUrl = null;
        HttpClient client;
        public ApiCall(IConfiguration configuration)
        {
            baseUrl = configuration.GetSection("api")["baseUrl"];
            client = new HttpClient();
            client.BaseAddress=new Uri(baseUrl);
           
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>(string apiName)
        {
            var response = await client.GetAsync(apiName);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<T> GetByIdAsync<T>(string url, int? id =null)
        {
            HttpResponseMessage response=null;
            if (id == null)
            {
                response = await client.GetAsync($"{url}");
            }
            else 
            {
                 response = await client.GetAsync($"{url}/{id}");
            }
            
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        //Get collection by using Id

        public async Task<IEnumerable<T>> GetAllByIdAsync<T>(string url, int? id = null)
        {
            HttpResponseMessage response = null;
            if (id == null)
            {
                response = await client.GetAsync($"{url}");
            }
            else
            {
                response = await client.GetAsync($"{url}");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<T>>();
        }

        public async Task<bool> CreateAsync<T>(string url, T entity)
        {
            var response = await client.PostAsJsonAsync(url, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync<T>(string url, int id, T entity)
        {
            var response = await client.PutAsJsonAsync($"{url}/{id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync<T>(string url, int id)
        {
            var response = await client.DeleteAsync($"{url}/{id}");
            return response.IsSuccessStatusCode;
        }
    
    }
}
