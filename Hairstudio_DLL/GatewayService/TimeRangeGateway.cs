using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Hairstudio_DLL.Entities;

namespace Hairstudio_DLL.GatewayService
{
    public class TimeRangeGateway : IGatewayService<TimeRange>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://examfall2016webapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public TimeRange Create(TimeRange t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);

                HttpResponseMessage response = client.PostAsJsonAsync("api/TimeRanges", t).Result;
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
                HttpResponseMessage response = client.GetAsync($"api/TimeRanges/{ID}").Result;
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
                HttpResponseMessage response = client.GetAsync("api/TimeRanges").Result;
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
                HttpResponseMessage response = client.DeleteAsync($"api/TimeRanges/{t.ID}").Result;
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
                HttpResponseMessage response = client.PutAsJsonAsync($"api/TimeRanges/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<TimeRange>().Result;
                }
                return null;
            }
        }
    }
}
