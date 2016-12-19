using System;
using System.ComponentModel.DataAnnotations;

namespace Hairstudio_DLL.Entities
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

    }
}
