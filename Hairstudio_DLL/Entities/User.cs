using System.ComponentModel.DataAnnotations;

namespace Hairstudio_DLL.Entities
{
    public class User : IEntity
    {
        #region IEntity

        public int ID { get; set; }

        #endregion
        /*User : IEntity
        - Username
        - Password
        - Name
        - Phone Number
        - Email
        - UserType(string)*/
        [Display(Name = "Brugernavn")]
        public string Username { get; set; }
        [Display(Name = "Kodeord")]
        public string Password { get; set; }
        [Display(Name = "Navn")]
        public virtual string Name { get; set; }
        [Display(Name = "Tlf. Nummer")]
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Brugertype")]
        public string UserType { get; set; }


    }
}
