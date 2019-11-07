using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Abstract
{
    public interface IQuestionService : IBaseService<Question>
    {
        ICollection<Question> GetAll(int examID);
    }
}
