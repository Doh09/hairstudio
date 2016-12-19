using System.ComponentModel.DataAnnotations;

namespace Hairstudio_DLL.Entities
{
    public class Message : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*Message (for website, e.g. welcome message) : IEntity
        - AreaMessageIsUsed (for example "welcome")
        - Description
        */
        [Display(Name = "Område på hjemmesiden")]
        public string AreaMessageIsUsed { get; set; }
        [Display(Name = "Tekst/link")]
        public string Description { get; set; }

    }
}
