using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KO.BLL.Abstract;
using KO.Entities;
using KO.Web.UI.MVC.ExtensionMethods;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Member member)
        {
            if (ModelState.IsValid)
            {
                string LoginMessage = memberService.UserLogin(member);
                if (String.IsNullOrEmpty(LoginMessage))
                {
                    HttpContext.Session.SetObject("Member", member);
                    return RedirectToAction("Index", "Member");
                }
                else
                    ModelState.AddModelError("", LoginMessage);
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
            }
            return View(member);
        }
    }
}