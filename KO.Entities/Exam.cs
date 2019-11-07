using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Entities
{
    public class Exam : BaseEntity
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MemberExam> MemberExams { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
