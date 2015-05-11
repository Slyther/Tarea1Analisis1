using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class NewUserTypeModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [DisplayName("User Type Name")]
        public string UserTypeName { get; set; }
        public long ID { get; set; }
    }
}