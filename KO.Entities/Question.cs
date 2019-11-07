using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Entities
{
    public class Question : BaseEntity
    {
        public string QuestionText { get; set; }
        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<Option> Options { get; set; }


    }
}
