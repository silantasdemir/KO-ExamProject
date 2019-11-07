using KO.BLL.Abstract;
using KO.DAL.Abstract;
using KO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KO.BLL.Concreate
{
    public class QuestionService : IQuestionService
    {
        IQuestionDAL questionDAL;
        public QuestionService(IQuestionDAL questionDAL)
        {
            this.questionDAL = questionDAL;
        }
        public void Delete(Question entity)
        {
            questionDAL.Remove(entity);
        }
        public Question Get(int entityID)
        {
            return questionDAL.Get(a => a.ID == entityID);
        }
        public ICollection<Question> GetAll()
        {
            return questionDAL.GetAll();
        }

        public ICollection<Question> GetAll(int examID)
        {
            return questionDAL.GetAll(a => a.ExamID == examID);
        }

        public void Insert(Question entity)
        {
            questionDAL.Add(entity);
        }
        public void Update(Question entity)
        {
            questionDAL.Update(entity);
        }
    }
}
