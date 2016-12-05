using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class VIewModel_CreateAppointment
    {
        public Appointment Appointment { get; set; }
        public List<Hairdresser> Hairdressers { get; set; }
        public List<Customer> Customers { get; set; }
        public List<int> selectedHairdresserID { get; set; }
        public List<int> selectedCustomerID { get; set; }
    }
}