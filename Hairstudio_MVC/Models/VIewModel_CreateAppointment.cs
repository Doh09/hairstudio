﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Hairstudio_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class ViewModel_CreateAppointment
    {
        [Required]
        public Appointment Appointment { get; set; }
        public List<Hairdresser> Hairdressers { get; set; }
        public List<Customer> Customers { get; set; }
        [Required]
        public List<int> selectedHairdresserID { get; set; }
        [Required]
        public List<int> selectedCustomerID { get; set; }
    }
}