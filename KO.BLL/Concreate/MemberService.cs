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
        public string UserLogin(Member member)
        {
            if (memberDAL.Get(a => a.ID == member.ID).Username == member.Username)
            {
                if (memberDAL.Get(a => a.ID == member.ID).Password == member.Password)
                    return null;
                else
                    return "Sifre Yanlis";
            }
            else
                return "Kullanici Bulunamadi";
        }
    }
}
