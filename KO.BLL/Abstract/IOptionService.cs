using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Abstract
{
    public interface IOptionService : IBaseService<Option>
    {
        ICollection<Option> GetAll(int questionID);

    }
}
