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
    public class AccountController : Controller
    {
        IMemberService memberService;
        public AccountController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        public IActionResult Login()
        {
            HttpContext.Session.Remove("Member");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Member member)
        {
            if (ModelState.IsValid)
            {
                Member temp = memberService.UserLogin(member.Username, member.Password);
                if (temp != null)
                {
                    HttpContext.Session.SetObject("Member", member);
                    return RedirectToAction("MemberExamList", "Member");
                }
                else
                    ViewBag.Error = "Kullanici Bulunamadi";
            }
            return View(member);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Member member)
        {
            if (ModelState.IsValid)
            {
                memberService.Insert(member);
                return RedirectToAction("Login", "Account");
            }
            else
                ViewBag.Error = "Kayit Basarisiz";

            return View(member);
        }
    }
}