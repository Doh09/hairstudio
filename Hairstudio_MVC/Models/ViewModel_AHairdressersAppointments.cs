using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HSRestAPI_DLL.Entities;

namespace Hairstudio_MVC.Models
{
    public class ViewModel_AHairdressersAppointments
    {
        public int HairdresserID { get; set; }
        public string HairdresserName { get; set; }
        public virtual List<TimeRange> WorkingDays { get; set; }
        //public List<TimeRange> WorkingDays = new List<TimeRange>();
        public virtual List<Appointment> Appointments { get; set; }
    }
}