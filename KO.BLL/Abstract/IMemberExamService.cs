using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Abstract
{
    public interface IMemberExamService : IBaseService<MemberExam>
    {
        ICollection<MemberExam> GetAll(int memberID);
    }
}
