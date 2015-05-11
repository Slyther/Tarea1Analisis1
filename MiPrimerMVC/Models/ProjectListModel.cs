using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimerMVC.Models
{
    public class ProjectListModel
    {
        public List<ProjectListModel> ProjectList { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
    }
}