using KO.BLL.Abstract;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Concreate
{
    public class ExamService : IExamService
    {
        IExamDAL examDAL;
        public ExamService(IExamDAL examDAL)
        {
            this.examDAL = examDAL;
        }
        public void Delete(Exam entity)
        {
            examDAL.Remove(entity);
        }
        public Exam Get(int entityID)
        {
            return examDAL.Get(a => a.ID == entityID);
        }
        public ICollection<Exam> GetAll()
        {
            return examDAL.GetAll();
        }
        public void Insert(Exam entity)
        {
            examDAL.Add(entity);
        }
        public void Update(Exam entity)
        {
            examDAL.Update(entity);
        }
    }
}
