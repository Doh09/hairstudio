using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class ServiceOffered : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*ServiceOffered : IEntity
        - Message
        - Price
        */
        [Display(Name = "Produkt/serviceydelse")]
        public string Message { get; set; }
        [Display(Name = "Pris")]
        public double Price { get; set; }

    }
}
