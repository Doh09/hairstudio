namespace Hairstudio_DLL.Entities
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
