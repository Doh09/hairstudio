using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Hairstudio_DLL.Entities
{
    public class Customer : User
    {
        public Customer()
        {
            UserType = "Customer";
        }
        /*Customer : User //ID and other variables inherited are tested in User.
        - Appointments
         */
        [Display(Name = "Kundenavn")]
        public override string Name { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
