using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Entities
{
    public class Member : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<MemberExam> MemberExams { get; set; }

    }
}
