using KO.BLL.Abstract;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Concreate
{
    public class MemberExamService : IMemberExamService
    {
        IMemberExamDAL memberExamDAL;
        public MemberExamService(IMemberExamDAL memberExamDAL)
        {
            this.memberExamDAL = memberExamDAL;
        }
        public void Delete(MemberExam entity)
        {
            memberExamDAL.Remove(entity);
        }
        public MemberExam Get(int entityID)
        {
            return memberExamDAL.Get(a => a.ID == entityID);
        }
        public ICollection<MemberExam> GetAll()
        {
            return memberExamDAL.GetAll();
        }
        public ICollection<MemberExam> GetAll(int memberID)
        {
            return memberExamDAL.GetAll(a => a.MemberID == memberID);
        }

        public void Insert(MemberExam entity)
        {
            memberExamDAL.Add(entity);
        }
        public void Update(MemberExam entity)
        {
            memberExamDAL.Update(entity);
        }
    }
}
