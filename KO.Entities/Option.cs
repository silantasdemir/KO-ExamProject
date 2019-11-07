using KO.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Entities
{
    public class Option : BaseEntity
    {
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

    }
}
