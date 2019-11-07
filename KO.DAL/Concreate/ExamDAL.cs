using KO.Core.DAL.EntityFramework;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.DAL.Concreate
{
    public class ExamDAL : EFRepositoryBase<Exam,KO_DbContext>, IExamDAL
    {
    }
}
