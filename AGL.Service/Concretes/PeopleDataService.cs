using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AGL.Domain;
using AGL.Service.Contracts;
using Newtonsoft.Json;

namespace AGL.Service.Concretes
{
    public class PeopleDataService : IPeopleDataService
    {
        private readonly HttpMessageHandler _httpHandler;

        public PeopleDataService(HttpMessageHandler httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var result = new List<Person>();
            using (var httpClient = new HttpClient(_httpHandler))
            {
                var data = await httpClient.GetAsync(ConfigurationManager.AppSettings["PeopleServiceUrl"]);
                if (data.IsSuccessStatusCode)
                {
                    var contentString = await data.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Person>>(contentString);
                }
                else
                {
                    //TODO some sort of logging
                    return null;
                }
            }
        }
    }
}
