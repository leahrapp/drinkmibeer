using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using DrinkMiBeer.Core.Interfaces;

using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Models; 
namespace DrinkMiBeer.Core.Services
{
    public class PublicApiService<T>:IPublicApiService<T>
    {
       
        public async Task<List<T>> GetApi(UrlModel url )
        {
            
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url.BaseUrl);
                    var response = await client.GetAsync(url.ResponseString);
                    response.EnsureSuccessStatusCode();

                    var results = await response.Content.ReadAsStringAsync();

                    var rawInfo = JsonConvert.DeserializeObject<List<T>>(results);
                    
                    return rawInfo; 

                }
                catch (HttpRequestException httpRequestException)
                {
                    return null;
                }

            }
        }

    }
}
