using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hairstudio_DLL.Entities
{
    public class Hairdresser : User
    {
        public Hairdresser()
        {
            UserType = "Hairdresser";
        }
        /*Hairdresser : User //ID and other variables inherited are tested in User.
        - Working hours
        - Appointments
         */
        [Display(Name = "Frisørnavn")]
        public override string Name { get; set; }
        public virtual List<TimeRange> WorkingDays { get; set; } = new List<TimeRange>();
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
