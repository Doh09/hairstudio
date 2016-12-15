using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Message : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*Message (for website, e.g. welcome messagge) : IEntity
        - AreaMessageIsUsed (for example "Welcome message")
        - Description
        */
        [Display(Name = "Område på hjemmesiden")]
        public string AreaMessageIsUsed { get; set; }
        [Display(Name = "Tekst/link")]
        public string Description { get; set; }

    }
}
