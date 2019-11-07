﻿using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Abstract
{
    public interface IMemberService : IBaseService<Member>
    {
        string UserLogin(Member member);
    }
}
