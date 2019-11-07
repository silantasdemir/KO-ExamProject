using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KO.BLL.Abstract;
using KO.Entities;
using KO.Web.UI.MVC.ExtensionMethods;
using KO.Web.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KO.Web.UI.MVC.Controllers
{
    public class MemberController : Controller
    {
        IMemberService memberService;
        IMemberExamService memberExamService;
        IExamService examService;
        public MemberController(IMemberService memberService, IMemberExamService memberExamService, IExamService examService)
        {
            this.memberService = memberService;
            this.memberExamService = memberExamService;
            this.examService = examService;
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

    }
}