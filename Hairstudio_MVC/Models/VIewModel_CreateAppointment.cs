using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class VIewModel_CreateAppointment
    {
        [Required]
        public Appointment Appointment { get; set; }
        [Required]
        public List<Hairdresser> Hairdressers { get; set; }
        [Required]
        public List<Customer> Customers { get; set; }
        [Required]
        public List<int> selectedHairdresserID { get; set; }
        [Required]
        public List<int> selectedCustomerID { get; set; }
    }
}