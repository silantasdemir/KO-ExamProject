using KO.BLL.Abstract;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Concreate
{
    public class OptionService : IOptionService
    {
        IOptionDAL optionDAL;
        public OptionService(IOptionDAL optionDAL)
        {
            this.optionDAL = optionDAL;
        }
        public void Delete(Option entity)
        {
            optionDAL.Remove(entity);
        }
        public Option Get(int entityID)
        {
            return optionDAL.Get(a => a.ID == entityID);
        }
        public ICollection<Option> GetAll()
        {
            return optionDAL.GetAll();
        }
        public ICollection<Option> GetAll(int questionID)
        {
            return optionDAL.GetAll(a => a.QuestionID == questionID);
        }
        public void Insert(Option entity)
        {
            optionDAL.Add(entity);
        }
        public void Update(Option entity)
        {
            optionDAL.Update(entity);
        }
    }
}
