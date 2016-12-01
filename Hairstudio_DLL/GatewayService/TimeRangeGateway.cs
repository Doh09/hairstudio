using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using Newtonsoft.Json;

namespace Hairstudio_DLL
{
    public class TimeRangeGateway : IGatewayService<TimeRange>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:27282/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public TimeRange Create(TimeRange t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);

                HttpResponseMessage response = client.PostAsJsonAsync("api/Hairdressers", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<TimeRange>().Result;
                }
                return null;
            }
        }

        public TimeRange Get(int ID)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync($"api/Hairdressers/{ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<TimeRange>().Result;
                }
                return null;
            }
        }

        public List<TimeRange> GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("api/Hairdressers").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<TimeRange>>().Result;
                }
                return null;
            }
        }

        public bool Remove(TimeRange t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.DeleteAsync($"api/Hairdressers/{t.ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<TimeRange>().Result != null;
                }
                return false;
            }
        }

        public TimeRange Update(TimeRange t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PutAsJsonAsync($"api/Hairdressers/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<TimeRange>().Result;
                }
                return null;
            }
        }
    }
}
