using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KO.BLL.Abstract;
using KO.Entities;
using KO.UI.MVC.Helper;
using KO.Web.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KO.Web.UI.MVC.Controllers
{
    public class ExamController : Controller
    {
        IExamService examService;
        IQuestionService questionService;
        IOptionService optionService;
        String Url;
        public ExamController(IExamService examService, IQuestionService questionService, IOptionService optionService)
        {
            this.examService = examService;
            this.questionService = questionService;
            this.optionService = optionService;
            Url = "https://www.wired.com/feed/rss";
        }
        public IActionResult DescriptionPartial(string description)
        {

            return PartialView("DescriptionPartial", description);
        }
        public IActionResult ExamCreate()
        {
            List<Post> postList = RSSHelper.GetAllPost(Url).ToList();
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in postList.Take(5))
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.Header,
                    Value = item.Description

                });
            }
            ViewBag.Post = selectLists;
            return View();
        }
        [HttpPost]
        public IActionResult ExamCreate(ExamDTO exam)
        {
            List<Post> postList = RSSHelper.GetAllPost(Url).ToList();

            Exam newExam = new Exam();
            newExam.Header = postList.Where(a => a.Description == exam.Description).FirstOrDefault().Header;
            newExam.Description = exam.Description;
            examService.Insert(newExam);

            for (int i = 0; i < 4; i++)
            {
                Question newQuestion = new Question();
                newQuestion.ExamID = newExam.ID;
                newQuestion.QuestionText = exam.Questions[i].QuestionText;
                questionService.Insert(newQuestion);

                for (int j = 0; j < 4; j++)
                {
                    Option newOption = new Option();
                    newOption.QuestionID = newQuestion.ID;
                    newOption.OptionText = exam.Options[i].OptionText;
                    newOption.IsCorrect = (j + 65 == exam.Answers[i] ? true : false);
                    optionService.Insert(newOption);
                }
            }

            return RedirectToAction("Login", "Account");
        }
        public IActionResult ExamList()
        {
            var examList = examService.GetAll();
            return View(examList);
        }
        public IActionResult ExamDelete(int id)
        {
            Exam exam = examService.Get(id);
            List<Question> questions = questionService.GetAll(exam.ID).ToList();

            foreach (Question question in questions)
            {
                List<Option> options = optionService.GetAll(question.ID).ToList();

                foreach (Option option in options)
                    optionService.Delete(option);

                questionService.Delete(question);
            }

            examService.Delete(exam);

            return RedirectToAction("ExamList");
        }

        public IActionResult ExamComplete(int id)
        {
            return View();
        }
    }
}