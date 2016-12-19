using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Hairstudio_DLL.Entities;

namespace Hairstudio_DLL.GatewayService
{
    public class AppointmentGateway : IGatewayService<Appointment>
    {
        private void SetUpClientConnection(HttpClient client)
        {
            client.BaseAddress = new Uri("http://examfall2016webapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Appointment Create(Appointment t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                //Presumably an issue here due to hairdresser/customer being null.
                HttpResponseMessage response = client.PostAsJsonAsync("api/Appointments", t).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Appointment>().Result;
                }
                return null;
            }
        }

        public Appointment Get(int ID)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync($"api/Appointments/{ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Appointment>().Result;
                }
                return null;
            }
        }

        public List<Appointment> GetAll()
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.GetAsync("api/Appointments").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Appointment>>().Result;
                }
                return null;
            }
        }

        public bool Remove(Appointment t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.DeleteAsync($"api/Appointments/{t.ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Appointment>().Result != null;
                }
                return false;
            }
        }

        public Appointment Update(Appointment t)
        {
            using (var client = new HttpClient())
            {
                SetUpClientConnection(client);
                HttpResponseMessage response = client.PutAsJsonAsync($"api/Appointments/{t.ID}", t).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Appointment>().Result;
                }
                return null;
            }
        }
    }
}
