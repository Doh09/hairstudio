using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Appointment : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*Appointment : IEntity
        - TimeRange
        - Hairdresser
        - Customer
         */
        public virtual TimeRange TimeRange { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public Customer Customer { get; set; }
    }
}
