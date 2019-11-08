using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Abstract
{
    public interface IMemberService : IBaseService<Member>
    {
        Member UserLogin(string username, string pass);
    }
}
