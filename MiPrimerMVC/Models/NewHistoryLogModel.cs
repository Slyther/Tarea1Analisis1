using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerMVC.Models
{
    public class NewHistoryLogModel
    {
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [DisplayName("User Type")]
        public string UserType { get; set; }
        public List<NewUserTypeModel> UserTypeList { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [DisplayName("Goal")]
        public string Goal { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Text)]
        [DisplayName("Reason")]
        public string Reason { get; set; }
        public long ID { get; set; }

        public IEnumerable<SelectListItem> UserTypeItems
        {
            get { return new SelectList(UserTypeList, "Id", "UserTypeName"); }
        }
    }
}