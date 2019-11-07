using KO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KO.Web.UI.MVC.Models
{
    public class ExamDTO
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public Question[] Questions { get; set; }
        public char[] Answers { get; set; }
        public Option[] Options { get; set; }

    }
}
