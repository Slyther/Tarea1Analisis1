using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.Models
{
    public class NewProjectModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Project Description")]
        public string ProjectDescription { get; set; }

        public long ID { get; set; }
    }
}