using KO.BLL.Abstract;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Concreate
{
    public class MemberService : IMemberService
    {
        IMemberDAL memberDAL;
        public MemberService(IMemberDAL memberDAL)
        {
            this.memberDAL = memberDAL;
        }
        public void Delete(Member entity)
        {
            memberDAL.Remove(entity);
        }
        public Member Get(int entityID)
        {
            return memberDAL.Get(a => a.ID == entityID);
        }
        public ICollection<Member> GetAll()
        {
            return memberDAL.GetAll();
        }
        public void Insert(Member entity)
        {
            memberDAL.Add(entity);
        }
        public void Update(Member entity)
        {
            memberDAL.Update(entity);
        }
        public Member UserLogin(string username, string pass)
        {
            return memberDAL.Get(a => a.Username == username && a.Password == pass);
        }
    }
}
