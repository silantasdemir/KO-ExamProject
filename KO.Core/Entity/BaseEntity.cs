using System;
using System.Collections.Generic;
using System.Text;

namespace KO.Core.Entity
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseEntity()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }

    }
}
