using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KO.BLL.Abstract;
using KO.Entities;
using KO.Web.UI.MVC.CustomFilters;
using KO.Web.UI.MVC.ExtensionMethods;
using KO.Web.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KO.Web.UI.MVC.Controllers
{
    //[ServiceFilter(typeof(MemberLoginFilter))]
    public class MemberController : Controller
    {
        IMemberService memberService;
        IMemberExamService memberExamService;
        IExamService examService;
        IQuestionService questionService;
        IOptionService optionService;
        public MemberController(IMemberService memberService, IMemberExamService memberExamService, IExamService examService, IQuestionService questionService, IOptionService optionService)
        {
            this.memberService = memberService;
            this.memberExamService = memberExamService;
            this.examService = examService;
            this.questionService = questionService;
            this.optionService = optionService;
        }
        public IActionResult MemberExamList()
        {
            Member member = HttpContext.Session.GetObject<Member>("Member");
            var memberExams = memberExamService.GetAll(member.ID);
            List<MemberExamsDTO> memberExamDTOs = new List<MemberExamsDTO>();
            foreach (var item in memberExams)
            {
                Exam exam = examService.Get(item.ExamID);
                memberExamDTOs.Add(new MemberExamsDTO { Description = exam.Description, Header = exam.Header, Score = item.Score });
            }
            return View(memberExamDTOs);
        }
        public IActionResult Exam(int id)
        {
            Exam exam = examService.Get(id);

            ExamDTO examDTO = new ExamDTO();
            examDTO.Header = exam.Header;
            examDTO.Description = exam.Description;
            examDTO.Questions = questionService.GetAll(exam.ID).ToArray();

            List<Option> options = new List<Option>();

            for (int i = 0; i < 4; i++)
                options.AddRange(optionService.GetAll(examDTO.Questions[i].ID));

            examDTO.Options = options.ToArray();

            return View(examDTO);
        }
        public IActionResult ExamComplete()
        {
            return View();
        }
    }
}