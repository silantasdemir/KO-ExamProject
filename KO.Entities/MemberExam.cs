using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Entities
{
    public class MemberExam : BaseEntity
    {
        public int MemberID { get; set; }
        public int ExamID { get; set; }
        public int Score { get; set; }

        public virtual Member Member { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
