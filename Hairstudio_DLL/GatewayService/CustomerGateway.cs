using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_DLL.GatewayService
{
    class CustomerGateway : IGatewayService<Customer>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:27282/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Customer Create(Customer t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                //Presumably an issue here due to hairdresser/customer being null.
                HttpResponseMessage response = client.PostAsJsonAsync("api/Customers", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Customer>().Result;
                }
                return null;
            }
        }

        public Customer Get(int ID)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync($"api/Customers/{ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Customer>().Result;
                }
                return null;
            }
        }

        public List<Customer> GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("api/Customers").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Customer>>().Result;
                }
                return null;
            }
        }

        public bool Remove(Customer t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.DeleteAsync($"api/Customers/{t.ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Customer>().Result != null;
                }
                return false;
            }
        }

        public Customer Update(Customer t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PutAsJsonAsync($"api/Customers/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Customer>().Result;
                }
                return null;
            }
        }
    }
}
