using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class TimeRange : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*TimeRange : IEntity
        - TheDate
        - Start time
        - End time
         */
        [DataType(DataType.Date)]
        [Display(Name = "Dato")]
        public DateTime TheDate { get; set; } = DateTime.Now;
        [DataType(DataType.Time)]
        [Display(Name = "Aftalt tidspunkt")]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [DataType(DataType.Time)]
        [Display(Name = "Forventet sluttidspunkt")]
        public DateTime EndTime { get; set; } = DateTime.Now;

        #region TheDate
        /// <summary>
        /// Gets the date of the TimeRange object.
        /// The time of the DateTime object used is set to 00:00:00, so only the TheDate is used.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return TheDate.Date;//Ensure only return date and not time.
        }

        /// <summary>
        /// Sets the date of the TimeRange object.
        /// The time of the DateTime object used is set to 00:00:00, so only the TheDate is used.
        /// </summary>
        public void SetDate(DateTime date)
        {
            TheDate = date.Date;
        }
        #endregion

    }
}
