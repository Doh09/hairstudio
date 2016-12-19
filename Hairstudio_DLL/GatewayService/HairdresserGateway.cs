using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Hairstudio_DLL.Entities;

namespace Hairstudio_DLL.GatewayService
{
    public class HairdresserGateway : IGatewayService<Hairdresser>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://examfall2016webapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Hairdresser Create(Hairdresser t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);

                HttpResponseMessage response = client.PostAsJsonAsync("api/Hairdressers", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Hairdresser>().Result;
                }
                return null;
            }
        }

        public Hairdresser Get(int ID)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync($"api/Hairdressers/{ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Hairdresser>().Result;
                }
                return null;
            }
        }

        public List<Hairdresser> GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("api/Hairdressers").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Hairdresser>>().Result;
                }
                return null;
            }
        }

        public bool Remove(Hairdresser t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.DeleteAsync($"api/Hairdressers/{t.ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Hairdresser>().Result != null;
                }
                return false;
            }
        }

        public Hairdresser Update(Hairdresser t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PutAsJsonAsync($"api/Hairdressers/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Hairdresser>().Result;
                }
                return null;
            }
        }
    }
}
