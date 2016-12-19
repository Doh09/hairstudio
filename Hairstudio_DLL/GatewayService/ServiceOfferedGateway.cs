using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Hairstudio_DLL.Entities;

namespace Hairstudio_DLL.GatewayService
{
    public class ServiceOfferedGateway : IGatewayService<ServiceOffered>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://examfall2016webapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ServiceOffered Create(ServiceOffered t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);

                HttpResponseMessage response = client.PostAsJsonAsync("api/ServicesOffered", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ServiceOffered>().Result;
                }
                return null;
            }
        }

        public ServiceOffered Get(int ID)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync($"api/ServicesOffered/{ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ServiceOffered>().Result;
                }
                return null;
            }
        }

        public List<ServiceOffered> GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("api/ServicesOffered").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<ServiceOffered>>().Result;
                }
                return null;
            }
        }

        public bool Remove(ServiceOffered t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.DeleteAsync($"api/ServicesOffered/{t.ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ServiceOffered>().Result != null;
                }
                return false;
            }
        }

        public ServiceOffered Update(ServiceOffered t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PutAsJsonAsync($"api/ServicesOffered/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ServiceOffered>().Result;
                }
                return null;
            }
        }
    }
}
