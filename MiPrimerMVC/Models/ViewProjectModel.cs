using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimerMVC.Models
{
    public class ViewProjectModel
    {
        public bool IsUserType { get; set; }
        public bool IsPostModel { get; set; }
        public List<ViewProjectModel> UserTypeList { get; set; }
        public List<ViewProjectModel> HistoryList { get; set; }
        public string UserType { get; set; }
        public string Goal { get; set; }
        public string Reason { get; set; }
        public long Id { get; set; }
    }
}